using Newtonsoft.Json;

namespace RevitMCPCommandSet.Models.Architecture;

public class LevelInfo
{
    ///     Name of the level
    [JsonProperty("name")]
    public string Name { get; set; }

    ///     Elevation of the level in millimeters
    [JsonProperty("elevation")]
    public double Elevation { get; set; }

    ///     Optional description of the level
    [JsonProperty("description")]
    public string Description { get; set; }

    ///     Optional parameter to indicate if this is a main level
    [JsonProperty("isMainLevel")]
    public bool IsMainLevel { get; set; } = true;

    ///     Optional parameter to indicate if this level should be used for building story
    [JsonProperty("isBuildingStory")]
    public bool IsBuildingStory { get; set; } = true;

    ///     Optional parameter to indicate if this level should be used for computation
    [JsonProperty("computationHeight")]
    public double ComputationHeight { get; set; }

    ///     Optional parameter to indicate if this level should be used for view plan
    [JsonProperty("viewPlanOffset")]
    public double ViewPlanOffset { get; set; }

    ///     Optional parameter to indicate if this level should be used for view section
    [JsonProperty("viewSectionOffset")]
    public double ViewSectionOffset { get; set; }

    ///     Optional parameter to indicate if this level should be used for view elevation
    [JsonProperty("viewElevationOffset")]
    public double ViewElevationOffset { get; set; }
}
