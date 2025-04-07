using Newtonsoft.Json;

namespace RevitMCPCommandSet.Models.Views;

///     Information for viewport creation
public class ViewportCreationInfo
{
    ///     Default constructor
    public ViewportCreationInfo()
    {
        Parameters = new Dictionary<string, object>();
    }

    ///     Sheet ID to place viewport on
    [JsonProperty("sheetId")]
    public int SheetId { get; set; }

    ///     View ID to place in viewport
    [JsonProperty("viewId")]
    public int ViewId { get; set; }

    ///     X position on sheet in millimeters
    [JsonProperty("positionX")]
    public double PositionX { get; set; }

    ///     Y position on sheet in millimeters
    [JsonProperty("positionY")]
    public double PositionY { get; set; }

    ///     Viewport type ID
    [JsonProperty("viewportTypeId")]
    public int ViewportTypeId { get; set; }

    ///     Whether to display the view title
    [JsonProperty("displayTitle")]
    public bool? DisplayTitle { get; set; }

    ///     Override scale for the viewport
    [JsonProperty("scaleOverride")]
    public int ScaleOverride { get; set; }

    ///     Viewport label text
    [JsonProperty("labelText")]
    public string LabelText { get; set; } = string.Empty;

    ///     Rotation angle in degrees
    [JsonProperty("rotation")]
    public double Rotation { get; set; }

    ///     Additional parameters
    [JsonProperty("parameters")]
    public Dictionary<string, object> Parameters { get; set; }
}
