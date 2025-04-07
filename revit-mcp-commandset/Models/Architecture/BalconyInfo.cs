using Newtonsoft.Json;
using RevitMCPCommandSet.Models.Common;

namespace RevitMCPCommandSet.Models.Architecture;

///     Information about a balcony
public class BalconyInfo
{
    ///     Default constructor
    public BalconyInfo()
    {
        Location = new JZPoint(0, 0, 0);
    }

    ///     Constructor with position and dimensions
    public BalconyInfo(double x, double y, double z, double width, double depth, double level = 0)
    {
        Location = new JZPoint(x, y, z);
        Width = width;
        Depth = depth;
        Level = level;
    }

    ///     Balcony corner position (mm)
    [JsonProperty("location")]
    public JZPoint Location { get; set; }

    ///     Balcony width (mm)
    [JsonProperty("width")]
    public double Width { get; set; }

    ///     Balcony length (mm) - projection distance from wall
    [JsonProperty("depth")]
    public double Depth { get; set; }

    ///     Balcony floor thickness (mm)
    [JsonProperty("thickness")]
    public double Thickness { get; set; }

    ///     Host floor elevation (mm)
    [JsonProperty("level")]
    public double Level { get; set; }

    ///     Host wall for the balcony (reference ID)
    [JsonProperty("hostWallId")]
    public string HostWallId { get; set; }

    ///     Railing type
    [JsonProperty("railingType")]
    public string RailingType { get; set; } // Glass, Metal, etc.

    ///     Railing height (mm)
    [JsonProperty("railingHeight")]
    public double RailingHeight { get; set; }

    ///     Balcony floor material
    [JsonProperty("floorMaterial")]
    public string FloorMaterial { get; set; }

    ///     Railing material
    [JsonProperty("railingMaterial")]
    public string RailingMaterial { get; set; }

    ///     Additional options
    [JsonProperty("options")]
    public Dictionary<string, object> Options { get; set; } = new();
}
