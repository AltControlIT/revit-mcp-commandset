using Newtonsoft.Json;
using RevitMCPCommandSet.Models.Common;

namespace RevitMCPCommandSet.Models.Architecture;

///     Information about a door
public class DoorInfo
{
    ///     Default constructor
    public DoorInfo()
    {
        Location = new JZPoint(0, 0, 0);
    }

    ///     Constructor with position and dimensions
    public DoorInfo(double x, double y, double z, double width, double height, double level = 0)
    {
        Location = new JZPoint(x, y, z);
        Width = width;
        Height = height;
        Level = level;
    }

    ///     Door position (mm)
    [JsonProperty("location")]
    public JZPoint Location { get; set; }

    ///     Host wall for the door (reference ID)
    [JsonProperty("hostWallId")]
    public string HostWallId { get; set; }

    ///     Door width (mm)
    [JsonProperty("width")]
    public double Width { get; set; }

    ///     Door height (mm)
    [JsonProperty("height")]
    public double Height { get; set; }

    ///     Height from floor (mm)
    [JsonProperty("elevation")]
    public double Elevation { get; set; }

    ///     Host floor elevation (mm)
    [JsonProperty("level")]
    public double Level { get; set; }

    ///     Door type
    [JsonProperty("type")]
    public string Type { get; set; } // Single, Double, Sliding, etc.

    ///     Door type ID in Revit
    [JsonProperty("typeId")]
    public int TypeId { get; set; }

    ///     Door material
    [JsonProperty("material")]
    public string Material { get; set; }

    ///     Door opening angle (degrees)
    [JsonProperty("openingAngle")]
    public double OpeningAngle { get; set; }

    ///     Additional options
    [JsonProperty("options")]
    public Dictionary<string, object> Options { get; set; } = new();
}
