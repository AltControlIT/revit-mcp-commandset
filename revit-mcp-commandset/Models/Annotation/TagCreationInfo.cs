using Newtonsoft.Json;
using RevitMCPCommandSet.Models.Common;

namespace RevitMCPCommandSet.Models.Annotation;

///     Information about tag creation parameters
public class TagCreationInfo
{
    ///     Default constructor
    public TagCreationInfo()
    {
        Location = new JZPoint(0, 0, 0);
        Options = new Dictionary<string, object>();
    }

    ///     Tag location point (mm)
    [JsonProperty("location")]
    public JZPoint Location { get; set; }

    ///     Element ID to tag
    [JsonProperty("elementId")]
    public int ElementId { get; set; } = -1;

    ///     Tag orientation (horizontal=0, vertical=1)
    [JsonProperty("orientation")]
    public int Orientation { get; set; }

    ///     Tag rotation in degrees
    [JsonProperty("rotation")]
    public double Rotation { get; set; }

    ///     Is tag leader visible
    [JsonProperty("hasLeader")]
    public bool HasLeader { get; set; }

    ///     Tag type ID
    [JsonProperty("tagTypeId")]
    public int TagTypeId { get; set; } = -1;

    ///     Tag category (Door, Window, Wall, etc.)
    [JsonProperty("tagCategory")]
    public string TagCategory { get; set; } = "";

    ///     View ID - view to create tag in
    [JsonProperty("viewId")]
    public int ViewId { get; set; } = -1;

    ///     Additional options
    [JsonProperty("options")]
    public Dictionary<string, object> Options { get; set; }
}
