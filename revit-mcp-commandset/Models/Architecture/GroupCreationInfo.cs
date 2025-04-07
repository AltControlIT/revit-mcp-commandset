using Newtonsoft.Json;

namespace RevitMCPCommandSet.Models.Architecture;

///     Information for group creation from elements
public class GroupCreationInfo
{
    ///     Default constructor
    public GroupCreationInfo()
    {
        ElementIds = new List<int>();
    }

    ///     Name for the new group
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    ///     Element IDs to include in the group
    [JsonProperty("elementIds")]
    public List<int> ElementIds { get; set; }
}

///     Information for placing a group instance
public class GroupInstanceInfo
{
    ///     Group type ID to place
    [JsonProperty("groupTypeId")]
    public int GroupTypeId { get; set; }

    ///     Insertion point for the group (millimeters)
    [JsonProperty("insertionPoint")]
    public Point InsertionPoint { get; set; }

    ///     Rotation angle in degrees
    [JsonProperty("rotation")]
    public double Rotation { get; set; }

    ///     Mirror the group about X axis
    [JsonProperty("mirrorAboutX")]
    public bool MirrorAboutX { get; set; }

    ///     Mirror the group about Y axis
    [JsonProperty("mirrorAboutY")]
    public bool MirrorAboutY { get; set; }
}

///     Result of group creation or placement
public class GroupResult
{
    ///     Group instance ID
    [JsonProperty("groupId")]
    public int GroupId { get; set; }

    ///     Group type ID
    [JsonProperty("groupTypeId")]
    public int GroupTypeId { get; set; }

    ///     Group name
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;
}
