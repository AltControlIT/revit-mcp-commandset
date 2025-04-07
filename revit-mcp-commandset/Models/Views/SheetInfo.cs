using Newtonsoft.Json;

namespace RevitMCPCommandSet.Models.Views;

///     Sheet information data structure
public class SheetInfo
{
    ///     Sheet element ID
    [JsonProperty("id")]
    public long Id { get; set; }

    ///     Sheet unique ID
    [JsonProperty("uniqueId")]
    public string UniqueId { get; set; }

    ///     Sheet number
    [JsonProperty("sheetNumber")]
    public string SheetNumber { get; set; }

    ///     Sheet name
    [JsonProperty("sheetName")]
    public string SheetName { get; set; }

    ///     Title block ID
    [JsonProperty("titleBlockId")]
    public int TitleBlockId { get; set; }
}
