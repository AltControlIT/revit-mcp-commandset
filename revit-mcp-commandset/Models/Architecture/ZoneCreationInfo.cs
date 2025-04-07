using Newtonsoft.Json;
using RevitMCPCommandSet.Models.Common;

namespace RevitMCPCommandSet.Models.Architecture;

///     Information about zone creation parameters
public class ZoneCreationInfo
{
    ///     Default constructor
    public ZoneCreationInfo()
    {
        Location = new JZPoint(0, 0, 0);
        RoomIds = new List<int>();
        Options = new Dictionary<string, object>();
    }

    ///     Zone name
    [JsonProperty("name")]
    public string Name { get; set; } = "Zone";

    ///     Zone location point (mm)
    [JsonProperty("location")]
    public JZPoint Location { get; set; }

    ///     List of room IDs to add to this zone
    [JsonProperty("roomIds")]
    public List<int> RoomIds { get; set; }

    ///     Zone color (RGB hex code)
    [JsonProperty("color")]
    public string Color { get; set; } = "#CCCCCC";

    ///     Additional options
    [JsonProperty("options")]
    public Dictionary<string, object> Options { get; set; }
}
