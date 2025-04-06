﻿// 
//                       RevitAPI-Solutions
// Copyright (c) Duong Tran Quang (DTDucas) (baymax.contact@gmail.com)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//

using Newtonsoft.Json;
using RevitMCPCommandSet.Models.Common;

namespace RevitMCPCommandSet.Models.MEP;

/// <summary>
///     Information about pipe creation parameters
/// </summary>
public class PipeCreationInfo
{
    /// <summary>
    ///     Default constructor
    /// </summary>
    public PipeCreationInfo()
    {
        StartPoint = new JZPoint(0, 0, 0);
        EndPoint = new JZPoint(0, 0, 0);
        Options = new Dictionary<string, object>();
    }

    /// <summary>
    ///     Constructor with position and dimensions
    /// </summary>
    /// <param name="startX">Start X position (mm)</param>
    /// <param name="startY">Start Y position (mm)</param>
    /// <param name="startZ">Start Z position (mm)</param>
    /// <param name="endX">End X position (mm)</param>
    /// <param name="endY">End Y position (mm)</param>
    /// <param name="endZ">End Z position (mm)</param>
    /// <param name="diameter">Pipe diameter (mm)</param>
    /// <param name="level">Base level elevation (mm)</param>
    public PipeCreationInfo(double startX, double startY, double startZ, double endX, double endY, double endZ,
        double diameter, double level = 0)
    {
        StartPoint = new JZPoint(startX, startY, startZ);
        EndPoint = new JZPoint(endX, endY, endZ);
        Diameter = diameter;
        BaseLevel = level;
    }

    /// <summary>
    ///     Pipe start position (mm)
    /// </summary>
    [JsonProperty("startPoint")]
    public JZPoint StartPoint { get; set; }

    /// <summary>
    ///     Pipe end position (mm)
    /// </summary>
    [JsonProperty("endPoint")]
    public JZPoint EndPoint { get; set; }

    /// <summary>
    ///     Pipe diameter (mm)
    /// </summary>
    [JsonProperty("diameter")]
    public double Diameter { get; set; }

    /// <summary>
    ///     Base level elevation (mm)
    /// </summary>
    [JsonProperty("baseLevel")]
    public double BaseLevel { get; set; }

    /// <summary>
    ///     Base offset (mm)
    /// </summary>
    [JsonProperty("baseOffset")]
    public double BaseOffset { get; set; }

    /// <summary>
    ///     Pipe system type
    /// </summary>
    [JsonProperty("systemType")]
    public string SystemType { get; set; } // Domestic Cold Water, Domestic Hot Water, Sanitary, etc.

    /// <summary>
    ///     Pipe type
    /// </summary>
    [JsonProperty("pipeType")]
    public string PipeType { get; set; } // Standard, Copper, PVC, etc.

    /// <summary>
    ///     Pipe type ID in Revit
    /// </summary>
    [JsonProperty("typeId")]
    public int TypeId { get; set; } = -1;

    /// <summary>
    ///     Pipe material
    /// </summary>
    [JsonProperty("material")]
    public string Material { get; set; }

    /// <summary>
    ///     Insulation type
    /// </summary>
    [JsonProperty("insulationType")]
    public string InsulationType { get; set; }

    /// <summary>
    ///     Insulation thickness (mm)
    /// </summary>
    [JsonProperty("insulationThickness")]
    public double InsulationThickness { get; set; }

    /// <summary>
    ///     Slope (%)
    /// </summary>
    [JsonProperty("slope")]
    public double Slope { get; set; }

    /// <summary>
    ///     Additional options
    /// </summary>
    [JsonProperty("options")]
    public Dictionary<string, object> Options { get; set; }
}