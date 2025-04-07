using Autodesk.Revit.UI;
using RevitMCPCommandSet.Models.Annotation;
using RevitMCPCommandSet.Models.Common;
using RevitMCPSDK.API.Interfaces;

namespace RevitMCPCommandSet.Services.AnnotationComponents;

///     Handles creation of dimension elements in Revit
public class CreateDimensionEventHandler : IExternalEventHandler, IWaitableExternalEventHandler
{
    #region Fields

    private UIApplication _uiApp;
    private UIDocument UiDoc => _uiApp.ActiveUIDocument;
    private Document Doc => UiDoc.Document;
    private readonly ManualResetEvent _resetEvent = new(false);
    private const double MILLIMETERS_TO_FEET = 1.0 / 304.8;

    #endregion

    #region Properties

    ///     List of dimensions to create
    public List<DimensionCreationInfo> DimensionsToCreate { get; private set; }

    ///     Result of the execution
    public AIResult<List<int>> Result { get; private set; }

    #endregion

    #region Public Methods

    ///     Sets parameters for dimension creation
    public void SetParameters(List<DimensionCreationInfo> dimensions)
    {
        DimensionsToCreate = dimensions;
        _resetEvent.Reset();
    }

    ///     Executes the dimension creation process
    public void Execute(UIApplication app)
    {
        _uiApp = app;
        try
        {
            var createdDimensionIds = new List<int>();

            // Process each dimension in the list
            foreach (var dimInfo in DimensionsToCreate)
            {
                // Get active view or specified view
                View view = null;
                if (dimInfo.ViewId > 0)
                {
                    var element = Doc.GetElement(new ElementId(dimInfo.ViewId));
                    view = element as View;
                }

                if (view == null)
                {
                    view = Doc.ActiveView;
                }

                using (var transaction = new Transaction(Doc, "Create Dimension"))
                {
                    transaction.Start();

                    try
                    {
                        // Convert points to Revit coordinates
                        var startPoint = ConvertToInternalCoordinates(
                            dimInfo.StartPoint.X,
                            dimInfo.StartPoint.Y,
                            dimInfo.StartPoint.Z
                        );

                        var endPoint = ConvertToInternalCoordinates(
                            dimInfo.EndPoint.X,
                            dimInfo.EndPoint.Y,
                            dimInfo.EndPoint.Z
                        );

                        var linePoint = dimInfo.LinePoint != null
                            ? ConvertToInternalCoordinates(
                                dimInfo.LinePoint.X,
                                dimInfo.LinePoint.Y,
                                dimInfo.LinePoint.Z
                              )
                            : new XYZ(
                                (startPoint.X + endPoint.X) / 2,
                                (startPoint.Y + endPoint.Y) / 2 + 1.0,
                                (startPoint.Z + endPoint.Z) / 2
                              );

                        // Create dimension based on type
                        Dimension dimension = null;

                        if (dimInfo.ElementIds != null && dimInfo.ElementIds.Count > 0)
                        {
                            // Create dimension between elements
                            var references = new ReferenceArray();
                            foreach (var elementId in dimInfo.ElementIds)
                            {
                                var element = Doc.GetElement(new ElementId(elementId));
                                if (element != null)
                                {
                                    // Get appropriate reference for this element
                                    foreach (var reference in GetReferences(element, view))
                                    {
                                        references.Append(reference);
                                    }
                                }
                            }

                            if (references.Size >= 2)
                            {
                                // Create dimension line with references
                                var line = Line.CreateBound(startPoint, endPoint);
                                dimension = Doc.Create.NewDimension(view, line, references);
                            }
                        }
                        else
                        {
                            // Create a simple dimension line between two points
                            var line = Line.CreateBound(startPoint, endPoint);

                            // Pick references from geometry in the view at those points
                            var refArray = new ReferenceArray();
                            var startRef = FindReferenceAtPoint(view, startPoint);
                            var endRef = FindReferenceAtPoint(view, endPoint);

                            if (startRef != null && endRef != null)
                            {
                                refArray.Append(startRef);
                                refArray.Append(endRef);
                                dimension = Doc.Create.NewDimension(view, line, refArray);
                            }
                        }

                        if (dimension != null)
                        {
                            // Apply dimension style if specified
                            if (dimInfo.DimensionStyleId > 0)
                            {
                                var dimensionType = Doc.GetElement(new ElementId(dimInfo.DimensionStyleId)) as DimensionType;
                                if (dimensionType != null)
                                {
                                    dimension.DimensionType = dimensionType;
                                }
                            }

                            // Apply additional parameters
                            ApplyDimensionParameters(dimension, dimInfo);

                            createdDimensionIds.Add(dimension.Id.IntegerValue);
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.RollBack();
                        throw;
                    }
                }
            }

            // Set successful result
            Result = new AIResult<List<int>>
            {
                Success = true,
                Message = $"Successfully created {createdDimensionIds.Count} dimensions. ElementIds saved in Response.",
                Response = createdDimensionIds
            };
        }
        catch (Exception ex)
        {
            // Set error result
            Result = new AIResult<List<int>>
            {
                Success = false,
                Message = $"Error creating dimensions: {ex.Message}",
                Response = new List<int>()
            };
            TaskDialog.Show("Error", $"Error creating dimensions: {ex.Message}");
        }
        finally
        {
            // Mark as completed
            _resetEvent.Set();
        }
    }


    ///     Waits for completion of the operation
    public bool WaitForCompletion(int timeoutMilliseconds = 10000)
    {
        return _resetEvent.WaitOne(timeoutMilliseconds);
    }

    ///     Gets the name of the handler
    public string GetName()
    {
        return "Create Dimension";
    }

    #endregion

    #region Private Methods

    ///     Gets references for an element for dimensioning
    private List<Reference> GetReferences(Element element, View view)
    {
        var references = new List<Reference>();

        // Handle different element types
        if (element is Wall wall)
        {
            // Get wall faces or edges for dimensioning
            var options = new Options();
            options.View = view;
            options.ComputeReferences = true;

            var geometry = wall.get_Geometry(options);

            if (geometry != null)
            {
                foreach (var obj in geometry)
                {
                    if (obj is Solid solid)
                    {
                        // Get the face references
                        foreach (Face face in solid.Faces)
                        {
                            references.Add(face.Reference);
                            break; // Usually just need the first face
                        }

                        // If no faces, try edges
                        if (references.Count == 0)
                        {
                            foreach (Edge edge in solid.Edges)
                            {
                                references.Add(edge.Reference);
                                break; // Usually just need the first edge
                            }
                        }
                    }
                }
            }

            // If still no references, use the location curve
            if (references.Count == 0 && wall.Location is LocationCurve locationCurve)
            {
                // Create a reference to the element itself
                references.Add(new Reference(wall));
            }
        }
        else if (element is FamilyInstance familyInstance)
        {
            // Try to get a reference from the family instance
            try
            {
                Reference centerRef = familyInstance.GetReferenceByName("Center");
                if (centerRef != null)
                {
                    references.Add(centerRef);
                }
                else
                {
                    // Fallback to generic reference
                    references.Add(new Reference(familyInstance));
                }
            }
            catch
            {
                // Fallback to generic reference
                references.Add(new Reference(familyInstance));
            }
        }
        else
        {
            // For other element types, create a generic reference
            references.Add(new Reference(element));
        }

        return references;
    }

    ///     Find a reference at a point in the view
    private Reference FindReferenceAtPoint(View view, XYZ point)
    {
        // In a non-3D view, we can't easily use ReferenceIntersector
        // Instead, we'll use a different approach based on view type

        try
        {
            // For simplicity in this example, just pick elements near the point
            // This is a less precise method but works for all view types
            FilteredElementCollector collector = new FilteredElementCollector(Doc, view.Id);

            // Get all elements in the view
            var elements = collector
                .WhereElementIsNotElementType()
                .ToElements();

            // Try to find the closest element to the specified point
            Element closestElement = null;
            double minDistance = double.MaxValue;

            foreach (var element in elements)
            {
                // Skip elements that don't have a valid location
                if (element.Location == null)
                    continue;

                // Get the closest point on this element
                XYZ elementPoint = null;

                if (element.Location is LocationPoint locationPoint)
                {
                    elementPoint = locationPoint.Point;
                }
                else if (element.Location is LocationCurve locationCurve)
                {
                    elementPoint = locationCurve.Curve.Project(point).XYZPoint;
                }
                else
                {
                    continue;
                }

                // Calculate distance to this element
                double distance = point.DistanceTo(elementPoint);

                // Update closest element if this one is closer
                if (distance < minDistance)
                {
                    closestElement = element;
                    minDistance = distance;
                }
            }

            // If we found a close enough element, return a reference to it
            if (closestElement != null && minDistance < 5.0) // 5 feet tolerance
            {
                return new Reference(closestElement);
            }
        }
        catch (Exception ex)
        {
            // Log error but continue processing
            TaskDialog.Show("Debug", $"Error finding reference at point: {ex.Message}");
        }

        return null;
    }

    ///     Applies parameters to the created dimension
    private void ApplyDimensionParameters(Dimension dimension, DimensionCreationInfo dimensionInfo)
    {
        if (dimensionInfo.Options == null) return;

        foreach (var option in dimensionInfo.Options)
        {
            var param = dimension.LookupParameter(option.Key);
            if (param == null) continue;

            if (option.Value is double doubleValue && param.StorageType == StorageType.Double)
            {
                param.Set(doubleValue * MILLIMETERS_TO_FEET);
            }
            else if (option.Value is int intValue && param.StorageType == StorageType.Integer)
            {
                param.Set(intValue);
            }
            else if (option.Value is string stringValue && param.StorageType == StorageType.String)
            {
                param.Set(stringValue);
            }
        }
    }

    ///     Converts millimeter coordinates to Revit internal coordinates (feet)
    private XYZ ConvertToInternalCoordinates(double x, double y, double z)
    {
        return new XYZ(
            x * MILLIMETERS_TO_FEET,
            y * MILLIMETERS_TO_FEET,
            z * MILLIMETERS_TO_FEET
        );
    }

    #endregion
}
