using Newtonsoft.Json;

namespace RevitMCPCommandSet.Models.Architecture;

///     Information for model curve creation
public class ModelCurveCreationInfo
{
    ///     Default constructor
    public ModelCurveCreationInfo()
    {
        Points = new List<Point>();
        Parameters = new Dictionary<string, object>();
    }

    ///     Curve type (Line, Arc, Circle, Ellipse, Spline)
    [JsonProperty("curveType")]
    public string CurveType { get; set; } = "Line";

    ///     Points defining the curve geometry
    [JsonProperty("points")]
    public List<Point> Points { get; set; }

    ///     Center point for circle, arc, ellipse
    [JsonProperty("center")]
    public Point Center { get; set; }

    ///     Radius for circle or arc in millimeters
    [JsonProperty("radius")]
    public double? Radius { get; set; }

    ///     X radius for ellipse in millimeters
    [JsonProperty("radiusX")]
    public double? RadiusX { get; set; }

    ///     Y radius for ellipse in millimeters
    [JsonProperty("radiusY")]
    public double? RadiusY { get; set; }

    ///     Rotation angle for ellipse in degrees
    [JsonProperty("rotation")]
    public double? Rotation { get; set; }

    ///     Start angle for arc in degrees
    [JsonProperty("startAngle")]
    public double? StartAngle { get; set; }

    ///     End angle for arc in degrees
    [JsonProperty("endAngle")]
    public double? EndAngle { get; set; }

    ///     Normal vector for curve plane
    [JsonProperty("normal")]
    public Point Normal { get; set; }

    ///     Sketch plane ID for curve
    [JsonProperty("sketchPlaneId")]
    public int SketchPlaneId { get; set; }

    ///     Line style name
    [JsonProperty("lineStyle")]
    public string LineStyle { get; set; }

    ///     Additional parameters
    [JsonProperty("parameters")]
    public Dictionary<string, object> Parameters { get; set; }
}
