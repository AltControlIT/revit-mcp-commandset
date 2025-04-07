using RevitMCPCommandSet.Models.Common;

namespace RevitMCPCommandSet.Utils;

///     Utilities for geometry processing in Revit
public static class GeometryUtils
{
    ///     Creates a rectangular curve array from dimensions and position
    public static CurveArray CreateRectangularFootprint(double width, double length, XYZ origin = null,
        double elevation = 0)
    {
        // If origin not provided, default to coordinate origin
        if (origin == null)
            origin = new XYZ(0, 0, elevation);
        else if (Math.Abs(origin.Z - elevation) > 1e-6)
            // If origin has a different Z than elevation, create a new origin with Z = elevation
            origin = new XYZ(origin.X, origin.Y, elevation);

        var curves = new CurveArray();

        // Create 4 vertices of the rectangle
        var p1 = origin;
        var p2 = new XYZ(origin.X + width, origin.Y, origin.Z);
        var p3 = new XYZ(origin.X + width, origin.Y + length, origin.Z);
        var p4 = new XYZ(origin.X, origin.Y + length, origin.Z);

        // Create 4 edges connecting the vertices
        curves.Append(Line.CreateBound(p1, p2));
        curves.Append(Line.CreateBound(p2, p3));
        curves.Append(Line.CreateBound(p3, p4));
        curves.Append(Line.CreateBound(p4, p1));

        return curves;
    }

    ///     Creates a rectangular CurveLoop from dimensions and position
    public static CurveLoop CreateRectangularBoundary(double width, double length, double elevation = 0,
        XYZ origin = null)
    {
        // If origin not provided, default to coordinate origin
        if (origin == null)
            origin = new XYZ(0, 0, elevation);
        else if (Math.Abs(origin.Z - elevation) > 1e-6)
            // If origin has a different Z than elevation, create a new origin with Z = elevation
            origin = new XYZ(origin.X, origin.Y, elevation);

        var curveLoop = new CurveLoop();

        // Create 4 vertices of the rectangle
        var p1 = origin;
        var p2 = new XYZ(origin.X + width, origin.Y, origin.Z);
        var p3 = new XYZ(origin.X + width, origin.Y + length, origin.Z);
        var p4 = new XYZ(origin.X, origin.Y + length, origin.Z);

        // Create 4 edges connecting the vertices
        curveLoop.Append(Line.CreateBound(p1, p2));
        curveLoop.Append(Line.CreateBound(p2, p3));
        curveLoop.Append(Line.CreateBound(p3, p4));
        curveLoop.Append(Line.CreateBound(p4, p1));

        return curveLoop;
    }

    ///     Calculates the center point of a rectangle
    public static XYZ CalculateRectangleCenter(double width, double length, XYZ origin)
    {
        return new XYZ(
            origin.X + width / 2,
            origin.Y + length / 2,
            origin.Z
        );
    }

    ///     Converts JZPoint to Revit XYZ (with unit conversion)
    public static XYZ ConvertToXYZ(JZPoint point)
    {
        if (point == null) return null;
        return new XYZ(
            point.X / 304.8,
            point.Y / 304.8,
            point.Z / 304.8
        );
    }

    ///     Converts Revit XYZ to JZPoint (with unit conversion)
    public static JZPoint ConvertToJZPoint(XYZ point)
    {
        if (point == null) return null;
        return new JZPoint(
            point.X * 304.8,
            point.Y * 304.8,
            point.Z * 304.8
        );
    }

    ///     Creates JZLine from two points
    public static JZLine CreateJZLine(JZPoint start, JZPoint end)
    {
        return new JZLine(start, end);
    }

    ///     Creates JZFace from array of points (polygon)
    public static JZFace CreateJZFaceFromPoints(List<JZPoint> points)
    {
        var face = new JZFace();
        var outerLoop = new List<JZLine>();

        // Create edges connecting consecutive points
        for (var i = 0; i < points.Count; i++)
        {
            var startPoint = points[i];
            var endPoint = points[(i + 1) % points.Count]; // Loop back to first point from last point
            outerLoop.Add(CreateJZLine(startPoint, endPoint));
        }

        face.OuterLoop = outerLoop;
        return face;
    }

    ///     Calculates distance between two points
    public static double Distance(XYZ p1, XYZ p2)
    {
        var dx = p2.X - p1.X;
        var dy = p2.Y - p1.Y;
        var dz = p2.Z - p1.Z;
        return Math.Sqrt(dx * dx + dy * dy + dz * dz);
    }

    ///     Finds intersection of two lines
    public static XYZ FindIntersection(Line line1, Line line2)
    {
        // Implement algorithm to calculate intersection
        // Simple method: use Revit API to find intersection
        var results = new IntersectionResultArray();
        if (line1.Intersect(line2, out results) == SetComparisonResult.Overlap && results.Size > 0)
            return results.get_Item(0).XYZPoint;
        return null;
    }

    ///     Finds normal vector of a plane
    public static XYZ ComputeNormal(XYZ p1, XYZ p2, XYZ p3)
    {
        var v1 = p2.Subtract(p1);
        var v2 = p3.Subtract(p1);
        var normal = v1.CrossProduct(v2);
        return normal.Normalize();
    }

    ///     Checks if two lines are parallel
    public static bool IsParallel(Line line1, Line line2, double tolerance = 1e-6)
    {
        var dir1 = line1.Direction.Normalize();
        var dir2 = line2.Direction.Normalize();

        // Check if direction vectors are parallel
        var dot = Math.Abs(dir1.DotProduct(dir2));
        return Math.Abs(dot - 1.0) < tolerance;
    }

    ///     Checks if two lines are perpendicular
    public static bool IsPerpendicular(Line line1, Line line2, double tolerance = 1e-6)
    {
        var dir1 = line1.Direction.Normalize();
        var dir2 = line2.Direction.Normalize();

        // Check if direction vectors are perpendicular
        var dot = Math.Abs(dir1.DotProduct(dir2));
        return dot < tolerance;
    }
}
