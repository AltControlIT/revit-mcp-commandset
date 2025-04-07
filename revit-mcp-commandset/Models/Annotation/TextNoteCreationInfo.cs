using Newtonsoft.Json;
using RevitMCPCommandSet.Models.Common;

namespace RevitMCPCommandSet.Models.Annotation;

///     Information about text note creation parameters
public class TextNoteCreationInfo
{
    ///     Default constructor
    public TextNoteCreationInfo()
    {
        Location = new JZPoint(0, 0, 0);
        Options = new Dictionary<string, object>();
    }

    ///     Text note location point (mm)
    [JsonProperty("location")]
    public JZPoint Location { get; set; }

    ///     Text content
    [JsonProperty("text")]
    public string Text { get; set; } = "";

    ///     Text rotation in degrees
    [JsonProperty("rotation")]
    public double Rotation { get; set; }

    ///     Text width (mm) - if zero, no width limit
    [JsonProperty("width")]
    public double Width { get; set; }

    ///     Text note type ID
    [JsonProperty("textNoteTypeId")]
    public int TextNoteTypeId { get; set; } = -1;

    ///     View ID - view to create text note in
    [JsonProperty("viewId")]
    public int ViewId { get; set; } = -1;

    ///     Text horizontal alignment (Left=0, Center=1, Right=2)
    [JsonProperty("horizontalAlign")]
    public int HorizontalAlign { get; set; }

    ///     Text vertical alignment (Top=0, Middle=1, Bottom=2)
    [JsonProperty("verticalAlign")]
    public int VerticalAlign { get; set; }

    ///     Additional options
    [JsonProperty("options")]
    public Dictionary<string, object> Options { get; set; }
}
