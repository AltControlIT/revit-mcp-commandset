using Newtonsoft.Json;
using RevitMCPCommandSet.Models.Common;

namespace RevitMCPCommandSet.Models.Architecture;

///     Information about room creation parameters
public class RoomCreationInfo
{
    ///     Default constructor
    public RoomCreationInfo()
    {
        Location = new JZPoint(0, 0, 0);
        Options = new Dictionary<string, object>();
    }

    ///     Room location point (mm)
    [JsonProperty("location")]
    public JZPoint Location { get; set; }

    ///     Room name
    [JsonProperty("name")]
    public string Name { get; set; } = "Room";

    ///     Room number
    [JsonProperty("number")]
    public string Number { get; set; }

    ///     Level elevation (mm)
    [JsonProperty("level")]
    public double Level { get; set; }

    ///     Level ID in Revit
    [JsonProperty("levelId")]
    public int LevelId { get; set; }

    ///     Room height (mm)
    [JsonProperty("height")]
    public double Height { get; set; }

    ///     Room phase ID
    [JsonProperty("phaseId")]
    public int PhaseId { get; set; }

    ///     Additional options
    [JsonProperty("options")]
    public Dictionary<string, object> Options { get; set; }
}
