using Newtonsoft.Json;
using RevitMCPCommandSet.Models.Common;

namespace RevitMCPCommandSet.Models.MEP;

///     Information about pipe creation parameters
public class PipeCreationInfo
{
    ///     Default constructor
    public PipeCreationInfo()
    {
        StartPoint = new JZPoint(0, 0, 0);
        EndPoint = new JZPoint(0, 0, 0);
        Options = new Dictionary<string, object>();
    }

    ///     Constructor with position and dimensions
    public PipeCreationInfo(double startX, double startY, double startZ, double endX, double endY, double endZ,
        double diameter, double level = 0)
    {
        StartPoint = new JZPoint(startX, startY, startZ);
        EndPoint = new JZPoint(endX, endY, endZ);
        Diameter = diameter;
        BaseLevel = level;
    }

    ///     Pipe start position (mm)
    [JsonProperty("startPoint")]
    public JZPoint StartPoint { get; set; }

    ///     Pipe end position (mm)
    [JsonProperty("endPoint")]
    public JZPoint EndPoint { get; set; }

    ///     Pipe diameter (mm)
    [JsonProperty("diameter")]
    public double Diameter { get; set; }

    ///     Base level elevation (mm)
    [JsonProperty("baseLevel")]
    public double BaseLevel { get; set; }

    ///     Base offset (mm)
    [JsonProperty("baseOffset")]
    public double BaseOffset { get; set; }

    ///     Pipe system type
    [JsonProperty("systemType")]
    public string SystemType { get; set; } // Domestic Cold Water, Domestic Hot Water, Sanitary, etc.

    ///     Pipe type
    [JsonProperty("pipeType")]
    public string PipeType { get; set; } // Standard, Copper, PVC, etc.

    ///     Pipe type ID in Revit
    [JsonProperty("typeId")]
    public int TypeId { get; set; } = -1;

    ///     Pipe material
    [JsonProperty("material")]
    public string Material { get; set; }

    ///     Insulation type
    [JsonProperty("insulationType")]
    public string InsulationType { get; set; }

    ///     Insulation thickness (mm)
    [JsonProperty("insulationThickness")]
    public double InsulationThickness { get; set; }

    ///     Slope (%)
    [JsonProperty("slope")]
    public double Slope { get; set; }

    ///     Additional options
    [JsonProperty("options")]
    public Dictionary<string, object> Options { get; set; }
}
