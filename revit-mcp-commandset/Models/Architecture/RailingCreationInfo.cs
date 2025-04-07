using Newtonsoft.Json;
using RevitMCPCommandSet.Models.Common;

namespace RevitMCPCommandSet.Models.Architecture;

///     Information about railing creation parameters
public class RailingCreationInfo
{
    ///     Default constructor
    public RailingCreationInfo()
    {
        PathPoints = new List<JZPoint>();
        Options = new Dictionary<string, object>();
    }

    ///     Constructor with basic parameters
    public RailingCreationInfo(double level, double height, List<JZPoint> pathPoints)
    {
        Level = level;
        Height = height;
        PathPoints = pathPoints ?? new List<JZPoint>();
        Options = new Dictionary<string, object>();
    }

    ///     Start point of the railing
    [JsonProperty("startPoint")]
    public JZPoint StartPoint { get; set; }

    ///     End point of the railing
    [JsonProperty("endPoint")]
    public JZPoint EndPoint { get; set; }

    ///     Path points defining the railing path
    [JsonProperty("pathPoints")]
    public List<JZPoint> PathPoints { get; set; }

    ///     Base level elevation (mm)
    [JsonProperty("level")]
    public double Level { get; set; }

    ///     Level offset (mm)
    [JsonProperty("levelOffset")]
    public double LevelOffset { get; set; }

    ///     Railing height (mm)
    [JsonProperty("height")]
    public double Height { get; set; } = 1070;

    ///     Host element ID for the railing (if attaching to a stair, ramp, etc.)
    [JsonProperty("hostElementId")]
    public int HostElementId { get; set; } = -1;

    ///     Is this a closed loop railing
    [JsonProperty("isClosedLoop")]
    public bool IsClosedLoop { get; set; }

    ///     Railing type ID in Revit
    [JsonProperty("typeId")]
    public int TypeId { get; set; } = -1;

    ///     Railing type name
    [JsonProperty("railingType")]
    public string RailingType { get; set; } = "Standard";

    ///     Railing material
    [JsonProperty("material")]
    public string Material { get; set; } = "Metal";

    ///     Additional options
    [JsonProperty("options")]
    public Dictionary<string, object> Options { get; set; }
}
