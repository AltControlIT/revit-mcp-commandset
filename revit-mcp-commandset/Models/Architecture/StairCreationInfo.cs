using Newtonsoft.Json;
using RevitMCPCommandSet.Models.Common;

namespace RevitMCPCommandSet.Models.Architecture;

///     Information about stair creation parameters
public class StairCreationInfo
{
    ///     Default constructor
    public StairCreationInfo()
    {
        PathPoints = new List<JZPoint>();
        Options = new Dictionary<string, object>();
    }

    ///     Constructor with basic parameters
    public StairCreationInfo(double baseLevel, double topLevel, double width, double riserHeight, double treadDepth)
    {
        BaseLevel = baseLevel;
        TopLevel = topLevel;
        Width = width;
        RiserHeight = riserHeight;
        TreadDepth = treadDepth;
        PathPoints = new List<JZPoint>();
        Options = new Dictionary<string, object>();
    }

    ///     Location point of the stair (starting point)
    [JsonProperty("location")]
    public JZPoint Location { get; set; }

    ///     Direction vector for the stair (XY plane)
    [JsonProperty("direction")]
    public JZPoint Direction { get; set; }

    ///     Start point of the stair
    [JsonProperty("startPoint")]
    public JZPoint StartPoint { get; set; }

    ///     End point of the stair
    [JsonProperty("endPoint")]
    public JZPoint EndPoint { get; set; }

    ///     Path points defining the stair path
    [JsonProperty("pathPoints")]
    public List<JZPoint> PathPoints { get; set; }

    ///     Base level elevation (mm)
    [JsonProperty("baseLevel")]
    public double BaseLevel { get; set; }

    ///     Top level elevation (mm)
    [JsonProperty("topLevel")]
    public double TopLevel { get; set; }

    ///     Stair width (mm)
    [JsonProperty("width")]
    public double Width { get; set; }

    ///     Riser height (mm)
    [JsonProperty("riserHeight")]
    public double RiserHeight { get; set; }

    ///     Tread depth (mm)
    [JsonProperty("treadDepth")]
    public double TreadDepth { get; set; }

    ///     Number of steps (if specified)
    [JsonProperty("stepCount")]
    public int StepCount { get; set; }

    ///     Stair type ID in Revit
    [JsonProperty("typeId")]
    public int TypeId { get; set; }

    ///     Stair type name
    [JsonProperty("stairType")]
    public string StairType { get; set; } = "Standard";

    ///     Stair material
    [JsonProperty("material")]
    public string Material { get; set; } = "Concrete";

    ///     Does the stair have a landing
    [JsonProperty("hasLanding")]
    public bool HasLanding { get; set; }

    ///     Landing width (if hasLanding is true)
    [JsonProperty("landingWidth")]
    public double LandingWidth { get; set; }

    ///     Landing depth (if hasLanding is true)
    [JsonProperty("landingDepth")]
    public double LandingDepth { get; set; }

    ///     Additional options
    [JsonProperty("options")]
    public Dictionary<string, object> Options { get; set; }
}
