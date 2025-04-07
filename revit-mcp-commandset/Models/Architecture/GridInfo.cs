using Newtonsoft.Json;

namespace RevitMCPCommandSet.Models.Architecture;

public class GridInfo
{
    ///     X-axis grid line positions in millimeters
    [JsonProperty("xAxis")]
    public List<double> XAxis { get; set; } = new();

    ///     Y-axis grid line positions in millimeters
    [JsonProperty("yAxis")]
    public List<double> YAxis { get; set; } = new();

    ///     Optional labels for X-axis grid lines
    [JsonProperty("xLabels")]
    public List<string> XLabels { get; set; } = new();

    ///     Optional labels for Y-axis grid lines
    [JsonProperty("yLabels")]
    public List<string> YLabels { get; set; } = new();

    ///     Optional Z-coordinate for the grid system in millimeters
    [JsonProperty("elevation")]
    public double Elevation { get; set; }

    ///     Optional parameter to indicate if the grid system should extend to 3D
    [JsonProperty("extendTo3D")]
    public bool ExtendTo3D { get; set; }

    ///     Optional parameter to specify the height of 3D grid lines in millimeters
    [JsonProperty("extendHeight")]
    public double ExtendHeight { get; set; }

    ///     Optional parameter to specify the bubble visibility
    [JsonProperty("bubbleVisible")]
    public bool BubbleVisible { get; set; } = true;

    ///     Optional parameter to specify the grid line weight
    [JsonProperty("lineWeight")]
    public int LineWeight { get; set; }
}
