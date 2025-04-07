using Newtonsoft.Json;
using RevitMCPCommandSet.Models.Common;

namespace RevitMCPCommandSet.Models.Architecture;

///     Overall description of a building
public class BuildingInfo
{
    ///     Default constructor
    public BuildingInfo()
    {
        // Initialize roof information
        Roof = new RoofInfo();
    }

    ///     Create a basic building structure with given dimensions
    public BuildingInfo(double width, double length, double height, int floorCount = 1)
    {
        Width = width;
        Length = length;
        Height = height;
        FloorCount = floorCount;
    }

    ///     Building name
    [JsonProperty("name")]
    public string Name { get; set; } = "Building";

    ///     Building description
    [JsonProperty("description")]
    public string Description { get; set; } = "";

    ///     Overall width (mm)
    [JsonProperty("width")]
    public double Width { get; set; }

    ///     Overall length (mm)
    [JsonProperty("length")]
    public double Length { get; set; }

    ///     Overall height (mm)
    [JsonProperty("height")]
    public double Height { get; set; }

    ///     Number of floors
    [JsonProperty("floorCount")]
    public int FloorCount { get; set; }

    ///     Height per floor (mm)
    [JsonProperty("floorHeight")]
    public double FloorHeight { get; set; }

    ///     Roof type
    [JsonProperty("roofType")]
    public string RoofType { get; set; } // Flat, Gable, Hip, etc.

    ///     Information about floors
    [JsonProperty("floors")]
    public List<FloorInfo> Floors { get; set; } = new();

    ///     List of walls
    [JsonProperty("walls")]
    public List<LineElement> Walls { get; set; } = new();

    ///     List of doors
    [JsonProperty("doors")]
    public List<DoorInfo> Doors { get; set; } = new();

    ///     List of windows
    [JsonProperty("windows")]
    public List<WindowInfo> Windows { get; set; } = new();

    ///     List of balconies
    [JsonProperty("balconies")]
    public List<BalconyInfo> Balconies { get; set; } = new();

    ///     Roof information
    [JsonProperty("roof")]
    public RoofInfo Roof { get; set; }

    ///     Materials for components
    [JsonProperty("materials")]
    public Dictionary<string, string> Materials { get; set; } = new();

    ///     Additional options
    [JsonProperty("options")]
    public Dictionary<string, object> Options { get; set; } = new();
}
