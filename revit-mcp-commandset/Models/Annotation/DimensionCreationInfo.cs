using Newtonsoft.Json;
using RevitMCPCommandSet.Models.Common;

namespace RevitMCPCommandSet.Models.Annotation;

///     Information about dimension creation parameters
public class DimensionCreationInfo
{
    ///     Default constructor
    public DimensionCreationInfo()
    {
        StartPoint = new JZPoint(0, 0, 0);
        EndPoint = new JZPoint(0, 0, 0);
        ElementIds = new List<int>();
        Options = new Dictionary<string, object>();
    }

    ///     Dimension start point (mm)
    [JsonProperty("startPoint")]
    public JZPoint StartPoint { get; set; }

    ///     Dimension end point (mm)
    [JsonProperty("endPoint")]
    public JZPoint EndPoint { get; set; }

    ///     Dimension line point - location of dimension line (mm)
    [JsonProperty("linePoint")]
    public JZPoint LinePoint { get; set; }

    ///     Elements to dimension
    [JsonProperty("elementIds")]
    public List<int> ElementIds { get; set; }

    ///     Dimension type
    [JsonProperty("dimensionType")]
    public string DimensionType { get; set; } = "Linear";

    ///     Dimension style ID
    [JsonProperty("dimensionStyleId")]
    public int DimensionStyleId { get; set; } = -1;

    ///     View ID - view to create dimension in
    [JsonProperty("viewId")]
    public int ViewId { get; set; } = -1;

    ///     Additional options
    [JsonProperty("options")]
    public Dictionary<string, object> Options { get; set; }
}
