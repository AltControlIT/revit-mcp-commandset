using Autodesk.Revit.UI;
using Newtonsoft.Json.Linq;
using RevitMCPSDK.API.Base;
using RevitMCPCommandSet.Models.Annotation;
using RevitMCPCommandSet.Services.AnnotationComponents;

namespace RevitMCPCommandSet.Commands.AnnotationComponents;

///     Command to create dimensions
public class CreateDimensionCommand : ExternalEventCommandBase
{
    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="uiApp">Revit UIApplication</param>
    public CreateDimensionCommand(UIApplication uiApp)
        : base(new CreateDimensionEventHandler(), uiApp)
    {
    }

    private CreateDimensionEventHandler _handler => (CreateDimensionEventHandler)Handler;

    ///     Command name
    public override string CommandName => "create_dimensions";

    /// <summary>
    ///     Execute dimension creation command
    /// </summary>
    /// <param name="parameters">JSON parameters</param>
    /// <param name="requestId">Request ID</param>
    /// <returns>Execution result</returns>
    public override object Execute(JObject parameters, string requestId)
    {
        try
        {
            // Parse parameters
            var dimensions = parameters["dimensions"]?.ToObject<List<DimensionCreationInfo>>();

            if (dimensions == null || dimensions.Count == 0)
                throw new ArgumentException("Dimension list cannot be empty");

            // Set parameters and execute
            _handler.SetParameters(dimensions);

            // Raise event and wait for completion
            if (RaiseAndWaitForCompletion(20000)) // 20 seconds timeout
                return _handler.Result;
            throw new TimeoutException("Dimension creation operation timed out");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error creating dimensions: {ex.Message}", ex);
        }
    }
}
