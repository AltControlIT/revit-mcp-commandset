using Newtonsoft.Json;

namespace RevitMCPCommandSet.Models.Views;

///     Information for sheet creation
public class SheetCreationInfo
{
    ///     Default constructor
    public SheetCreationInfo()
    {
        Parameters = new Dictionary<string, object>();
        RevisionIds = new List<int>();
    }

    ///     Sheet number
    [JsonProperty("sheetNumber")]
    public string SheetNumber { get; set; } = string.Empty;

    ///     Sheet name
    [JsonProperty("sheetName")]
    public string SheetName { get; set; } = string.Empty;

    ///     Title block type ID
    [JsonProperty("titleBlockTypeId")]
    public int TitleBlockTypeId { get; set; }

    ///     Title block family name
    [JsonProperty("titleBlockFamilyName")]
    public string TitleBlockFamilyName { get; set; } = string.Empty;

    ///     Title block type name
    [JsonProperty("titleBlockTypeName")]
    public string TitleBlockTypeName { get; set; } = string.Empty;

    ///     Revision IDs to apply to the sheet
    [JsonProperty("revisionIds")]
    public List<int> RevisionIds { get; set; }

    ///     Additional parameters
    [JsonProperty("parameters")]
    public Dictionary<string, object> Parameters { get; set; }
}
