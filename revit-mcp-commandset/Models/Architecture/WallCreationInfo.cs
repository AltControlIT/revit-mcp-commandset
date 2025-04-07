using Newtonsoft.Json;
using RevitMCPCommandSet.Models.Common;

namespace RevitMCPCommandSet.Models.Architecture;

///     Information about wall creation parameters
public class WallCreationInfo
{
    ///     Default constructor
    public WallCreationInfo()
    {
        StartPoint = new JZPoint(0, 0, 0);
        EndPoint = new JZPoint(0, 0, 0);
        Options = new Dictionary<string, object>();
    }

    ///     Constructor with position and dimensions
    public WallCreationInfo(double startX, double startY, double startZ, double endX, double endY, double endZ,
        double height, double thickness, double level = 0)
    {
        StartPoint = new JZPoint(startX, startY, startZ);
        EndPoint = new JZPoint(endX, endY, endZ);
        Height = height;
        Thickness = thickness;
        BaseLevel = level;
    }

    ///     Wall start position (mm)
    [JsonProperty("startPoint")]
    public JZPoint StartPoint { get; set; }

    ///     Wall end position (mm)
    [JsonProperty("endPoint")]
    public JZPoint EndPoint { get; set; }

    ///     Wall height (mm)
    [JsonProperty("height")]
    public double Height { get; set; }

    ///     Wall thickness (mm)
    [JsonProperty("thickness")]
    public double Thickness { get; set; }

    ///     Base level elevation (mm)
    [JsonProperty("baseLevel")]
    public double BaseLevel { get; set; }

    ///     Base offset (mm)
    [JsonProperty("baseOffset")]
    public double BaseOffset { get; set; }

    ///     Top constraint type (0=Unconstrained, 1=Up to level, 2=Unconnected height)
    [JsonProperty("topConstraintType")]
    public int TopConstraintType { get; set; }

    ///     Top level ID (only used if TopConstraintType = 1)
    [JsonProperty("topLevelId")]
    public int TopLevelId { get; set; }

    ///     Top offset (mm) (used if TopConstraintType = 1)
    [JsonProperty("topOffset")]
    public double TopOffset { get; set; }

    ///     Wall type
    [JsonProperty("wallType")]
    public string WallType { get; set; } = "Basic Wall"; // Basic Wall, Curtain Wall, etc.

    ///     Wall type ID in Revit
    [JsonProperty("typeId")]
    public int TypeId { get; set; }

    ///     Wall material
    [JsonProperty("material")]
    public string Material { get; set; } = "Concrete";

    ///     Is structural
    [JsonProperty("isStructural")]
    public bool IsStructural { get; set; } = true;

    ///     Flip wall direction
    [JsonProperty("flipped")]
    public bool Flipped { get; set; }

    ///     Additional options
    [JsonProperty("options")]
    public Dictionary<string, object> Options { get; set; }
}
