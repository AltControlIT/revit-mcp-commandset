using Newtonsoft.Json;
using RevitMCPCommandSet.Models.Common;

namespace RevitMCPCommandSet.Models.Architecture;

///     Type of opening
public enum OpeningType
{
    WallOpening,
    FloorOpening,
    RoofOpening,
    ShaftOpening
}

///     Shape of opening
public enum OpeningShape
{
    Rectangular,
    Circular,
    Custom
}

///     Information about opening creation parameters
public class OpeningCreationInfo
{
    ///     Default constructor
    public OpeningCreationInfo()
    {
        BoundaryPoints = new List<JZPoint>();
        Options = new Dictionary<string, object>();
    }

    ///     Constructor with basic parameters
    public OpeningCreationInfo(OpeningType openingType, JZPoint location, double width, double height)
    {
        OpeningType = openingType;
        Location = location;
        Width = width;
        Height = height;
        BoundaryPoints = new List<JZPoint>();
        Options = new Dictionary<string, object>();
    }

    ///     Type of opening
    [JsonProperty("openingType")]
    public OpeningType OpeningType { get; set; } = OpeningType.WallOpening;

    ///     Shape of opening
    [JsonProperty("shape")]
    public OpeningShape Shape { get; set; } = OpeningShape.Rectangular;

    ///     Location point for the opening
    [JsonProperty("location")]
    public JZPoint Location { get; set; }

    ///     Direction vector for the opening (for rectangular openings)
    [JsonProperty("direction")]
    public JZPoint Direction { get; set; }

    ///     Boundary points for custom shapes
    [JsonProperty("boundaryPoints")]
    public List<JZPoint> BoundaryPoints { get; set; }

    ///     Host element ID
    [JsonProperty("hostElementId")]
    public int HostElementId { get; set; }

    ///     Width of the opening (mm)
    [JsonProperty("width")]
    public double Width { get; set; }

    ///     Height of the opening (mm)
    [JsonProperty("height")]
    public double Height { get; set; }

    ///     Length of the opening (mm) - for rectangular floor/roof openings
    [JsonProperty("length")]
    public double Length { get; set; }

    ///     Sill height for wall openings (mm)
    [JsonProperty("sillHeight")]
    public double SillHeight { get; set; }

    ///     Additional options
    [JsonProperty("options")]
    public Dictionary<string, object> Options { get; set; }
}
