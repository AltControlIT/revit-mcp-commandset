using Newtonsoft.Json;
using RevitMCPCommandSet.Models.Common;

namespace RevitMCPCommandSet.Models.Architecture;

///     Information about a structural beam
public class BeamInfo
{
    ///     Default constructor
    public BeamInfo()
    {
        StartPoint = new JZPoint(0, 0, 0);
        EndPoint = new JZPoint(0, 0, 0);
        Options = new Dictionary<string, object>();
    }

    ///     Constructor with position and dimensions
    public BeamInfo(double startX, double startY, double startZ, double endX, double endY, double endZ,
        double width, double height, double level = 0)
    {
        StartPoint = new JZPoint(startX, startY, startZ);
        EndPoint = new JZPoint(endX, endY, endZ);
        Width = width;
        Height = height;
        Level = level;
    }

    ///     Beam start position (mm)
    [JsonProperty("startPoint")]
    public JZPoint StartPoint { get; set; }

    ///     Beam end position (mm)
    [JsonProperty("endPoint")]
    public JZPoint EndPoint { get; set; }

    ///     Beam width (mm)
    [JsonProperty("width")]
    public double Width { get; set; } = 300;

    ///     Beam height (mm)
    [JsonProperty("height")]
    public double Height { get; set; } = 500;

    ///     Host level elevation (mm)
    [JsonProperty("level")]
    public double Level { get; set; }

    ///     Beam offset from level (mm)
    [JsonProperty("levelOffset")]
    public double LevelOffset { get; set; }

    ///     Beam type
    [JsonProperty("type")]
    public string Type { get; set; } = "Concrete"; // Concrete, Steel, Wood, etc.

    ///     Beam family type ID in Revit
    [JsonProperty("typeId")]
    public int TypeId { get; set; } = -1;

    ///     Beam material
    [JsonProperty("material")]
    public string Material { get; set; } = "Concrete";

    ///     Structural parameters: Is load-bearing
    [JsonProperty("isLoadBearing")]
    public bool IsLoadBearing { get; set; } = true;

    ///     Additional options
    [JsonProperty("options")]
    public Dictionary<string, object> Options { get; set; }
}
