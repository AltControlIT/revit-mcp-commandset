using Newtonsoft.Json;
using RevitMCPCommandSet.Models.Common;

namespace RevitMCPCommandSet.Models.Architecture;

///     Information about ramp creation parameters
public class RampCreationInfo
{
    ///     Default constructor
    public RampCreationInfo()
    {
        PathPoints = new List<JZPoint>();
        BoundaryPoints = new List<JZPoint>();
        Options = new Dictionary<string, object>();
    }

    ///     Constructor with basic parameters
    public RampCreationInfo(double baseLevel, double topLevel, double width, List<JZPoint> pathPoints)
    {
        BaseLevel = baseLevel;
        TopLevel = topLevel;
        Width = width;
        PathPoints = pathPoints ?? new List<JZPoint>();
        BoundaryPoints = new List<JZPoint>();
        Options = new Dictionary<string, object>();
    }

    ///     Start point of the ramp
    [JsonProperty("startPoint")]
    public JZPoint StartPoint { get; set; }

    ///     End point of the ramp
    [JsonProperty("endPoint")]
    public JZPoint EndPoint { get; set; }

    ///     Path points defining the ramp path
    [JsonProperty("pathPoints")]
    public List<JZPoint> PathPoints { get; set; }

    ///     Boundary points defining the ramp outline (for custom ramps)
    [JsonProperty("boundaryPoints")]
    public List<JZPoint> BoundaryPoints { get; set; }

    ///     Base level elevation (mm)
    [JsonProperty("baseLevel")]
    public double BaseLevel { get; set; }

    ///     Top level elevation (mm)
    [JsonProperty("topLevel")]
    public double TopLevel { get; set; }

    ///     Base offset (mm)
    [JsonProperty("baseOffset")]
    public double BaseOffset { get; set; }

    ///     Top offset (mm)
    [JsonProperty("topOffset")]
    public double TopOffset { get; set; }

    ///     Ramp width (mm)
    [JsonProperty("width")]
    public double Width { get; set; }

    ///     Ramp slope (percent)
    [JsonProperty("slope")]
    public double Slope { get; set; }

    ///     Ramp type ID in Revit
    [JsonProperty("typeId")]
    public int TypeId { get; set; }

    ///     Ramp type name
    [JsonProperty("rampType")]
    public string RampType { get; set; }
    
    ///     Ramp material
    [JsonProperty("material")]
    public string Material { get; set; }

    ///     Is this a custom ramp (using form instead of built-in ramp)
    [JsonProperty("isCustomRamp")]
    public bool IsCustomRamp { get; set; }

    ///     Additional options
    [JsonProperty("options")]
    public Dictionary<string, object> Options { get; set; }
}
