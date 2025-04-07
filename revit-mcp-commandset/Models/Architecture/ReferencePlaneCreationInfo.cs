using Newtonsoft.Json;

namespace RevitMCPCommandSet.Models.Architecture;

///     Information for reference plane creation
public class ReferencePlaneCreationInfo
{
    ///     Default constructor
    public ReferencePlaneCreationInfo()
    {
        Points = new List<Point>();
        Parameters = new Dictionary<string, object>();
    }

    ///     Creation method (ByLine, ByNormal, ByPoints)
    [JsonProperty("creationMethod")]
    public string CreationMethod { get; set; } = "ByLine";

    ///     Name for the reference plane
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    ///     Bubble end point for line-based creation (millimeters)
    [JsonProperty("bubbleEnd")]
    public Point BubbleEnd { get; set; }

    ///     Free end point for line-based creation (millimeters)
    [JsonProperty("freeEnd")]
    public Point FreeEnd { get; set; }

    /// <summary>
    ///     Third point for defining the plane (millimeters)
    /// </summary>
    [JsonProperty("thirdPoint")]
    public Point ThirdPoint { get; set; }

    ///     Origin point for normal-based creation (millimeters)
    [JsonProperty("origin")]
    public Point Origin { get; set; }

    ///     Normal vector for normal-based creation
    [JsonProperty("normal")]
    public Point Normal { get; set; }

    ///     Length of the reference plane line in millimeters
    [JsonProperty("length")]
    public double Length { get; set; }

    ///     Points for creating reference plane (for ByPoints method)
    [JsonProperty("points")]
    public List<Point> Points { get; set; }

    ///     Additional parameters
    [JsonProperty("parameters")]
    public Dictionary<string, object> Parameters { get; set; }
}
