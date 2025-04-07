using Newtonsoft.Json;
using RevitMCPCommandSet.Models.Common;

namespace RevitMCPCommandSet.Models.Architecture;

///     Shape of shaft
public enum ShaftShape
{
    Rectangular,
    Circular,
    Custom
}

///     Information about shaft creation parameters
public class ShaftCreationInfo
{
    ///     Default constructor
    public ShaftCreationInfo()
    {
        BoundaryPoints = new List<JZPoint>();
        Options = new Dictionary<string, object>();
    }

    ///     Constructor with basic parameters
    public ShaftCreationInfo(JZPoint location, double width, double length, double baseLevel, double topLevel)
    {
        Location = location;
        Width = width;
        Length = length;
        BaseLevel = baseLevel;
        TopLevel = topLevel;
        BoundaryPoints = new List<JZPoint>();
        Options = new Dictionary<string, object>();
    }

    ///     Shape of shaft
    [JsonProperty("shape")]
    public ShaftShape Shape { get; set; } = ShaftShape.Rectangular;

    ///     Location point for the shaft
    [JsonProperty("location")]
    public JZPoint Location { get; set; }

    ///     Direction vector for the shaft (for rectangular shafts)
    [JsonProperty("direction")]
    public JZPoint Direction { get; set; }

    ///     Boundary points for custom shapes
    [JsonProperty("boundaryPoints")]
    public List<JZPoint> BoundaryPoints { get; set; }

    ///     Base level elevation (mm)
    [JsonProperty("baseLevel")]
    public double BaseLevel { get; set; }

    ///     Top level elevation (mm)
    [JsonProperty("topLevel")]
    public double TopLevel { get; set; }

    ///     Width of the shaft (mm)
    [JsonProperty("width")]
    public double Width { get; set; }

    ///     Length of the shaft (mm) - for rectangular shafts
    [JsonProperty("length")]
    public double Length { get; set; }

    ///     Shaft name
    [JsonProperty("name")]
    public string Name { get; set; } = "Shaft";

    ///     Shaft type (Elevator, Mechanical, etc.)
    [JsonProperty("shaftType")]
    public string ShaftType { get; set; } = "Elevator";

    ///     Additional options
    [JsonProperty("options")]
    public Dictionary<string, object> Options { get; set; }
}
