using Newtonsoft.Json;
using RevitMCPCommandSet.Models.Common;

namespace RevitMCPCommandSet.Models.Architecture;

public class FoundationInfo
{
    ///     Type of foundation (e.g., "Isolated", "Strip", "Raft", "Pile")
    [JsonProperty("type")]
    public string Type { get; set; } = "Isolated";

    ///     Location of the foundation in millimeters (X, Y, Z coordinates)
    [JsonProperty("location")]
    public JZPoint Location { get; set; } = new();

    ///     Width of the foundation in millimeters
    [JsonProperty("width")]
    public double Width { get; set; }

    ///     Length of the foundation in millimeters
    [JsonProperty("length")]
    public double Length { get; set; }

    ///     Thickness/depth of the foundation in millimeters
    [JsonProperty("thickness")]
    public double Thickness { get; set; }

    ///     Elevation of the foundation in millimeters
    [JsonProperty("elevation")]
    public double Elevation { get; set; }

    ///     Material of the foundation
    [JsonProperty("material")]
    public string Material { get; set; }

    ///     Optional ID of the column or wall supported by this foundation
    [JsonProperty("supportedElementId")]
    public int SupportedElementId { get; set; }

    ///     Optional rotation angle in degrees
    [JsonProperty("rotation")]
    public double Rotation { get; set; }

    ///     Optional parameter for strip foundation - path points
    [JsonProperty("path")]
    public List<JZPoint> Path { get; set; } = new();

    ///     Optional parameter for pile foundation - depth
    [JsonProperty("depth")]
    public double Depth { get; set; }

    ///     Optional parameter for pile foundation - diameter
    [JsonProperty("diameter")]
    public double Diameter { get; set; }

    ///     Optional parameter for raft foundation - boundary points
    [JsonProperty("boundary")]
    public List<JZPoint> Boundary { get; set; } = new();

    ///     Optional parameter for family type ID
    [JsonProperty("typeId")]
    public int TypeId { get; set; }
}
