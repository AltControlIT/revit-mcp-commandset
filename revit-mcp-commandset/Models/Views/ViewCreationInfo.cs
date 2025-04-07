using Newtonsoft.Json;

namespace RevitMCPCommandSet.Models.Views;

///     Information for view creation
public class ViewCreationInfo
{
    ///     Default constructor
    public ViewCreationInfo()
    {
        Parameters = new Dictionary<string, object>();
    }

    ///     View name
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    ///     View type (FloorPlan, CeilingPlan, Elevation, Section, 3D)
    [JsonProperty("viewType")]
    public string ViewType { get; set; } = "FloorPlan";

    ///     Level elevation in millimeters (for plan views)
    [JsonProperty("levelElevation")]
    public double LevelElevation { get; set; }

    ///     View detail level (Coarse, Medium, Fine)
    [JsonProperty("detailLevel")]
    public string DetailLevel { get; set; } = "Medium";

    ///     View scale (e.g., 100 for 1:100)
    [JsonProperty("scale")]
    public int Scale { get; set; } = 100;

    ///     View family type name
    [JsonProperty("viewFamilyTypeName")]
    public string ViewFamilyTypeName { get; set; } = string.Empty;

    ///     Template view unique ID to apply
    [JsonProperty("templateId")]
    public string TemplateId { get; set; } = string.Empty;

    ///     View direction for elevation/section views
    [JsonProperty("direction")]
    public Point Direction { get; set; }

    ///     Additional parameters
    [JsonProperty("parameters")]
    public Dictionary<string, object> Parameters { get; set; }
}
