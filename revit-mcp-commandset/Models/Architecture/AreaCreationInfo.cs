using Newtonsoft.Json;
using RevitMCPCommandSet.Models.Common;

namespace RevitMCPCommandSet.Models.Architecture;

///     Information about area creation parameters
public class AreaCreationInfo
{
    ///     Default constructor
    public AreaCreationInfo()
    {
        Location = new JZPoint(0, 0, 0);
        Options = new Dictionary<string, object>();
    }

    ///     Area location point (mm)
    [JsonProperty("location")]
    public JZPoint Location { get; set; }

    ///     Area name
    [JsonProperty("name")]
    public string Name { get; set; } = "Area";

    ///     Area level ID in Revit
    [JsonProperty("levelId")]
    public int LevelId { get; set; }

    ///     Level elevation (mm)
    [JsonProperty("level")]
    public double Level { get; set; }

    ///     Area scheme ID in Revit
    [JsonProperty("areaSchemeId")]
    public int AreaSchemeId { get; set; }

    ///     Area scheme name
    [JsonProperty("areaScheme")]
    public string AreaScheme { get; set; }

    ///     Area view ID in Revit
    [JsonProperty("areaViewId")]
    public int AreaViewId { get; set; }

    ///     Additional options
    [JsonProperty("options")]
    public Dictionary<string, object> Options { get; set; }
}
