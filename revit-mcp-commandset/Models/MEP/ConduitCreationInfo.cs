using Newtonsoft.Json;
using RevitMCPCommandSet.Models.Common;

namespace RevitMCPCommandSet.Models.MEP;

///     Information about conduit creation parameters
public class ConduitCreationInfo
{
    ///     Default constructor
    public ConduitCreationInfo()
    {
        StartPoint = new JZPoint(0, 0, 0);
        EndPoint = new JZPoint(0, 0, 0);
        Options = new Dictionary<string, object>();
    }

    ///     Constructor with position and dimensions
    public ConduitCreationInfo(double startX, double startY, double startZ, double endX, double endY, double endZ,
        double diameter, double level = 0)
    {
        StartPoint = new JZPoint(startX, startY, startZ);
        EndPoint = new JZPoint(endX, endY, endZ);
        Diameter = diameter;
        BaseLevel = level;
    }

    ///     Conduit start position (mm)
    [JsonProperty("startPoint")]
    public JZPoint StartPoint { get; set; }

    ///     Conduit end position (mm)
    [JsonProperty("endPoint")]
    public JZPoint EndPoint { get; set; }

    ///     Conduit diameter (mm)
    [JsonProperty("diameter")]
    public double Diameter { get; set; }

    ///     Base level elevation (mm)
    [JsonProperty("baseLevel")]
    public double BaseLevel { get; set; }

    ///     Base offset (mm)
    [JsonProperty("baseOffset")]
    public double BaseOffset { get; set; }

    ///     Conduit system type
    [JsonProperty("systemType")]
    public string SystemType { get; set; } // Power, Data, Communication, etc.

    ///     Conduit type
    [JsonProperty("conduitType")]
    public string ConduitType { get; set; } // Standard, EMT, IMC, RMC, etc.

    ///     Conduit type ID in Revit
    [JsonProperty("typeId")]
    public int TypeId { get; set; }

    ///     Conduit material>
    [JsonProperty("material")]
    public string Material { get; set; } = "Steel";

    ///     Additional options
    [JsonProperty("options")]
    public Dictionary<string, object> Options { get; set; }
}
