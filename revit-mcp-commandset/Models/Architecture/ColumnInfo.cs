using Newtonsoft.Json;
using RevitMCPCommandSet.Models.Common;

namespace RevitMCPCommandSet.Models.Architecture;

///     Information about a structural column
public class ColumnInfo
{
    ///     Default constructor
    public ColumnInfo()
    {
        Options = new Dictionary<string, object>();
    }

    ///     Constructor with position and dimensions
    public ColumnInfo(double x, double y, double z, double width, double depth, double height, double baseLevel)
    {
        Location = new JZPoint(x, y, z);
        Width = width;
        Depth = depth;
        Height = height;
        BaseLevel = baseLevel;
    }

    ///     Column position (mm)
    [JsonProperty("location")]
    public JZPoint Location { get; set; }

    ///     Column width (mm)
    [JsonProperty("width")]
    public double Width { get; set; }

    ///     Column depth (mm)
    [JsonProperty("depth")]
    public double Depth { get; set; }

    ///     Column height (mm)
    [JsonProperty("height")]
    public double Height { get; set; }

    ///     Base level elevation (mm)
    [JsonProperty("baseLevel")]
    public double BaseLevel { get; set; }

    ///     Top level elevation (mm)
    [JsonProperty("topLevel")]
    public double TopLevel { get; set; }

    ///     Column rotation (degrees)
    [JsonProperty("rotation")]
    public double Rotation { get; set; }

    ///     Column type
    [JsonProperty("type")]
    public string Type { get; set; }

    ///     Column family type ID in Revit
    [JsonProperty("typeId")]
    public int TypeId { get; set; }

    ///     Column material
    [JsonProperty("material")]
    public string Material { get; set; }

    ///     Column diameter (for circular columns, mm)
    [JsonProperty("diameter")]
    public double Diameter { get; set; }

    ///     Is structural
    [JsonProperty("isStructural")]
    public bool IsStructural { get; set; }

    ///     Additional options
    [JsonProperty("options")]
    public Dictionary<string, object> Options { get; set; }
}
