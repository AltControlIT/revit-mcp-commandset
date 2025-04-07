using Newtonsoft.Json;
using RevitMCPCommandSet.Models.Common;

namespace RevitMCPCommandSet.Models.Architecture;

///     Information about a window
public class WindowInfo
{
    ///     Default constructor
    public WindowInfo()
    {
        Location = new JZPoint(0, 0, 0);
    }

    ///     Constructor with position and dimensions
    public WindowInfo(double x, double y, double z, double width, double height, double sillHeight,
        double level)
    {
        Location = new JZPoint(x, y, z);
        Width = width;
        Height = height;
        SillHeight = sillHeight;
        Level = level;
    }

    ///     Window position (mm)
    [JsonProperty("location")]
    public JZPoint Location { get; set; }

    ///     Host wall for the window (reference ID)
    [JsonProperty("hostWallId")]
    public string HostWallId { get; set; }

    ///     Window width (mm)
    [JsonProperty("width")]
    public double Width { get; set; }

    ///     Window height (mm)
    [JsonProperty("height")]
    public double Height { get; set; }

    ///     Height from floor (mm)
    [JsonProperty("sillHeight")]
    public double SillHeight { get; set; }

    ///     Host floor elevation (mm)
    [JsonProperty("level")]
    public double Level { get; set; }

    ///     Window type
    [JsonProperty("type")]
    public string Type { get; set; } // Fixed, Casement, Sliding, etc.

    ///     Window type ID in Revit
    [JsonProperty("typeId")]
    public int TypeId { get; set; } = -1;

    ///     Window frame material
    [JsonProperty("frameMaterial")]
    public string FrameMaterial { get; set; }

    ///     Glass material
    [JsonProperty("glassMaterial")]
    public string GlassMaterial { get; set; }

    ///     Additional options
    [JsonProperty("options")]
    public Dictionary<string, object> Options { get; set; } = new();
}
