using Newtonsoft.Json;
using RevitMCPCommandSet.Models.Common;

namespace RevitMCPCommandSet.Models.Architecture;

///     Information about ceiling creation parameters
public class CeilingCreationInfo
{
    ///     Default constructor
    public CeilingCreationInfo()
    {
        BoundaryPoints = new List<JZPoint>();
        Openings = new List<List<JZPoint>>();
        Options = new Dictionary<string, object>();
    }

    ///     Constructor with basic parameters
    public CeilingCreationInfo(double level, double thickness, List<JZPoint> boundaryPoints)
    {
        Level = level;
        Thickness = thickness;
        BoundaryPoints = boundaryPoints ?? new List<JZPoint>();
        Openings = new List<List<JZPoint>>();
        Options = new Dictionary<string, object>();
    }

    ///     Base level elevation (mm)
    [JsonProperty("level")]
    public double Level { get; set; }

    ///     Ceiling thickness (mm)
    [JsonProperty("thickness")]
    public double Thickness { get; set; }

    ///     Ceiling boundary points (mm)
    [JsonProperty("boundaryPoints")]
    public List<JZPoint> BoundaryPoints { get; set; }

    ///     Holes/openings in the ceiling (list of boundary loops)
    [JsonProperty("openings")]
    public List<List<JZPoint>> Openings { get; set; }

    ///     Level offset (mm) - how far above the level
    [JsonProperty("levelOffset")]
    public double LevelOffset { get; set; }

    ///     Ceiling type ID in Revit
    [JsonProperty("typeId")]
    public int TypeId { get; set; }

    ///     Ceiling type name
    [JsonProperty("ceilingType")]
    public string CeilingType { get; set; }

    ///     Ceiling material
    [JsonProperty("material")]
    public string Material { get; set; }

    ///     Additional options
    [JsonProperty("options")]
    public Dictionary<string, object> Options { get; set; }
}
