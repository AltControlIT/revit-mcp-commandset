using Newtonsoft.Json;

namespace RevitMCPCommandSet.Models.Architecture;

///     Information about the building roof
public class RoofInfo
{
    ///     Default constructor
    public RoofInfo()
    {
        Options = new Dictionary<string, object>();
    }

    ///     Constructor with basic parameters
    public RoofInfo(string type, double level, double thickness, string material = "Concrete")
    {
        Type = type;
        Level = level;
        Thickness = thickness;
        Material = material;

        Options = new Dictionary<string, object>();
    }

    ///     Roof type
    [JsonProperty("type")]
    public string Type { get; set; } // Flat, Gable, Hip, etc.

    ///     Roof elevation (mm)
    [JsonProperty("level")]
    public double Level { get; set; }

    ///     Roof height (for pitched roofs) (mm)
    [JsonProperty("height")]
    public double Height { get; set; }

    ///     Roof thickness (mm)
    [JsonProperty("thickness")]
    public double Thickness { get; set; }

    ///     Roof slope (degrees)
    [JsonProperty("slope")]
    public double Slope { get; set; }

    ///     Roof overhang from walls (mm)
    [JsonProperty("overhang")]
    public double Overhang { get; set; }

    ///     Roof material
    [JsonProperty("material")]
    public string Material { get; set; }

    ///     Additional options
    [JsonProperty("options")]
    public Dictionary<string, object> Options { get; set; } = new();
}
