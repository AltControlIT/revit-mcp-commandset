using Newtonsoft.Json;
using RevitMCPCommandSet.Models.Common;

namespace RevitMCPCommandSet.Models.MEP;

///     Information about duct creation parameters
public class DuctCreationInfo
{
    ///     Default constructor
    public DuctCreationInfo()
    {
        StartPoint = new JZPoint(0, 0, 0);
        EndPoint = new JZPoint(0, 0, 0);
        Options = new Dictionary<string, object>();
    }

    ///     Constructor with position and dimensions
    public DuctCreationInfo(double startX, double startY, double startZ, double endX, double endY, double endZ,
        double width, double height, double level = 0)
    {
        StartPoint = new JZPoint(startX, startY, startZ);
        EndPoint = new JZPoint(endX, endY, endZ);
        Width = width;
        Height = height;
        BaseLevel = level;
    }

    ///     Duct start position (mm)
    [JsonProperty("startPoint")]
    public JZPoint StartPoint { get; set; }

    ///     Duct end position (mm)
    [JsonProperty("endPoint")]
    public JZPoint EndPoint { get; set; }

    ///     Duct width/diameter (mm) - for rectangular ducts this is width, for round ducts this is diameter
    [JsonProperty("width")]
    public double Width { get; set; }

    ///     Duct height (mm) - used only for rectangular ducts
    [JsonProperty("height")]
    public double Height { get; set; }

    ///     Base level elevation (mm)
    [JsonProperty("baseLevel")]
    public double BaseLevel { get; set; }

    ///     Base offset (mm)
    [JsonProperty("baseOffset")]
    public double BaseOffset { get; set; }

    ///     Duct system type
    [JsonProperty("systemType")]
    public string SystemType { get; set; } // Supply Air, Return Air, Exhaust Air

    ///     Duct type
    [JsonProperty("ductType")]
    public string DuctType { get; set; } // Rectangular Duct, Round Duct, Oval Duct, etc.

    ///     Duct type ID in Revit
    [JsonProperty("typeId")]
    public int TypeId { get; set; }

    ///     Duct material
    [JsonProperty("material")]
    public string Material { get; set; }

    ///     Insulation type
    [JsonProperty("insulationType")]
    public string InsulationType { get; set; }

    ///     Insulation thickness (mm)
    [JsonProperty("insulationThickness")]
    public double InsulationThickness { get; set; }

    ///     Additional options
    [JsonProperty("options")]
    public Dictionary<string, object> Options { get; set; }
}
