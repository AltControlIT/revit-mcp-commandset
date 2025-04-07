using Newtonsoft.Json;
using RevitMCPCommandSet.Models.Common;

namespace RevitMCPCommandSet.Models.MEP;

///     Information about equipment creation parameters
public class EquipmentCreationInfo
{
    ///     Default constructor
    public EquipmentCreationInfo()
    {
        Location = new JZPoint(0, 0, 0);
        Options = new Dictionary<string, object>();
    }

    ///     Constructor with position and dimensions
    public EquipmentCreationInfo(double x, double y, double z, double width, double depth, double height,
        double level = 0)
    {
        Location = new JZPoint(x, y, z);
        Width = width;
        Depth = depth;
        Height = height;
        BaseLevel = level;
    }

    ///     Equipment position (mm)
    [JsonProperty("location")]
    public JZPoint Location { get; set; }

    ///     Equipment rotation around Z-axis (degrees)
    [JsonProperty("rotation")]
    public double Rotation { get; set; }

    ///     Equipment width (mm)
    [JsonProperty("width")]
    public double Width { get; set; }

    ///     Equipment depth (mm)
    [JsonProperty("depth")]
    public double Depth { get; set; }

    ///     Equipment height (mm)
    [JsonProperty("height")]
    public double Height { get; set; }

    ///     Base level elevation (mm)
    [JsonProperty("baseLevel")]
    public double BaseLevel { get; set; }

    ///     Base offset (mm)
    [JsonProperty("baseOffset")]
    public double BaseOffset { get; set; }

    ///     Equipment category
    [JsonProperty("category")]
    public string Category { get; set; } =
        "Mechanical Equipment"; // Mechanical Equipment, Electrical Equipment, Plumbing Fixtures

    ///     Equipment type
    [JsonProperty("equipmentType")]
    public string EquipmentType { get; set; } // AHU, Pump, Fan, Panel, etc.

    ///     Equipment system
    [JsonProperty("system")]
    public string System { get; set; } // HVAC, Electrical, Plumbing, Fire Protection

    ///     Equipment family name
    [JsonProperty("familyName")]
    public string FamilyName { get; set; }

    ///     Equipment type ID in Revit
    [JsonProperty("typeId")]
    public int TypeId { get; set; }

    ///     Is electrical connected
    [JsonProperty("isElectricalConnected")]
    public bool IsElectricalConnected { get; set; }

    ///     Requires ventilation
    [JsonProperty("requiresVentilation")]
    public bool RequiresVentilation { get; set; }

    ///     Equipment power rating (watts)
    [JsonProperty("powerRating")]
    public double PowerRating { get; set; }

    ///     Additional options
    [JsonProperty("options")]
    public Dictionary<string, object> Options { get; set; }
}
