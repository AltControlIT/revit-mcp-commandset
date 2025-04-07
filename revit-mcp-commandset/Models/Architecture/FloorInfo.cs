using Newtonsoft.Json;
using RevitMCPCommandSet.Models.Common;

namespace RevitMCPCommandSet.Models.Architecture;

///     Information about a floor in Revit, used for both creation and retrieval
public class FloorInfo
{
    ///     Default constructor
    public FloorInfo()
    {
        BoundaryPoints = new List<JZPoint>();
        Openings = new List<List<JZPoint>>();
        Options = new Dictionary<string, object>();
    }

    ///     Constructor with basic parameters
    public FloorInfo(double level, double thickness, List<JZPoint> boundaryPoints)
    {
        Level = level;
        Thickness = thickness;
        BoundaryPoints = boundaryPoints ?? new List<JZPoint>();
        Openings = new List<List<JZPoint>>();
        Options = new Dictionary<string, object>();
    }

    ///     Element ID
    [JsonProperty("elementId")]
    public int ElementId { get; set; }

    ///     Floor name
    [JsonProperty("name")]
    public string Name { get; set; } = "Floor";

    ///     Base level elevation (mm)
    [JsonProperty("level")]
    public double Level { get; set; }

    ///     Floor height (mm) - the vertical dimension of the floor space
    [JsonProperty("height")]
    public double Height { get; set; }

    ///     Floor thickness (mm) - the physical thickness of the floor element
    [JsonProperty("thickness")]
    public double Thickness { get; set; }

    ///     Floor boundary points (mm)
    [JsonProperty("boundaryPoints")]
    public List<JZPoint> BoundaryPoints { get; set; }

    ///     Holes/openings in the floor (list of boundary loops)
    [JsonProperty("openings")]
    public List<List<JZPoint>> Openings { get; set; }

    ///     Level offset (mm)
    [JsonProperty("levelOffset")]
    public double LevelOffset { get; set; }

    ///     Floor type ID in Revit
    [JsonProperty("typeId")]
    public int TypeId { get; set; } = -1;

    ///     Floor type name
    [JsonProperty("floorType")]
    public string FloorType { get; set; }

    ///     Floor material
    [JsonProperty("material")]
    public string Material { get; set; }

    ///     Floor level name
    [JsonProperty("levelName")]
    public string LevelName { get; set; }

    ///     Is floor structural
    [JsonProperty("isStructural")]
    public bool IsStructural { get; set; }

    ///     Floor area (m²)
    [JsonProperty("area")]
    public double Area { get; set; }

    ///     Additional options
    [JsonProperty("options")]
    public Dictionary<string, object> Options { get; set; }
}
