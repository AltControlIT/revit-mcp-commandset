using Newtonsoft.Json;

namespace RevitMCPCommandSet.Models.Views;

///     Information for schedule creation
public class ScheduleCreationInfo
{
    ///     Default constructor
    public ScheduleCreationInfo()
    {
        Parameters = new Dictionary<string, object>();
        Fields = new List<ScheduleFieldInfo>();
        Filters = new List<ScheduleFilterInfo>();
        SortFields = new List<ScheduleSortInfo>();
        GroupFields = new List<ScheduleGroupInfo>();
    }

    ///     Schedule name
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    ///     Schedule type (Regular, KeySchedule, MaterialTakeoff)
    [JsonProperty("type")]
    public string Type { get; set; } = "Regular";

    ///     Category ID for the schedule
    [JsonProperty("categoryId")]
    public int CategoryId { get; set; }

    ///     Category name for the schedule
    [JsonProperty("categoryName")]
    public string CategoryName { get; set; } = string.Empty;

    ///     Template view unique ID to apply
    [JsonProperty("templateId")]
    public string TemplateId { get; set; } = string.Empty;

    ///     Show title in schedule
    [JsonProperty("showTitle")]
    public bool? ShowTitle { get; set; } = true;

    ///     Show column headers in schedule
    [JsonProperty("showHeaders")]
    public bool? ShowHeaders { get; set; } = true;

    ///     Show grid lines in schedule
    [JsonProperty("showGridLines")]
    public bool? ShowGridLines { get; set; } = true;

    ///     Show outlines in schedule
    [JsonProperty("showOutlines")]
    public bool? ShowOutlines { get; set; } = true;

    ///     Fields to include in the schedule
    [JsonProperty("fields")]
    public List<ScheduleFieldInfo> Fields { get; set; }
    
    ///     Filters to apply to the schedule
    [JsonProperty("filters")]
    public List<ScheduleFilterInfo> Filters { get; set; }

    ///     Clear existing filters before applying new ones
    [JsonProperty("clearExistingFilters")]
    public bool ClearExistingFilters { get; set; } = true;

    ///     Sort fields for the schedule
    [JsonProperty("sortFields")]
    public List<ScheduleSortInfo> SortFields { get; set; }

    ///     Clear existing sorts before applying new ones
    [JsonProperty("clearExistingSorts")]
    public bool ClearExistingSorts { get; set; } = true;

    ///     Group fields for the schedule
    [JsonProperty("groupFields")]
    public List<ScheduleGroupInfo> GroupFields { get; set; }

    ///     Clear existing groups before applying new ones
    [JsonProperty("clearExistingGroups")]
    public bool ClearExistingGroups { get; set; } = true;
    
    ///     Additional parameters
    [JsonProperty("parameters")]
    public Dictionary<string, object> Parameters { get; set; }
}

///     Information about a schedule field
public class ScheduleFieldInfo
{
    ///     Parameter ID for the field
    [JsonProperty("parameterId")]
    public int ParameterId { get; set; }

    ///     Parameter name for the field
    [JsonProperty("parameterName")]
    public string ParameterName { get; set; } = string.Empty;

    ///     Field type (Instance, Type, Count, Formula, Phasing)
    [JsonProperty("fieldType")]
    public string FieldType { get; set; } = "Instance";

    ///     Column heading for the field
    [JsonProperty("heading")]
    public string Heading { get; set; } = string.Empty;

    ///     Whether the field is a calculated field
    [JsonProperty("isCalculatedField")]
    public bool IsCalculatedField { get; set; }

    ///     Formula for calculated fields
    [JsonProperty("formula")]
    public string Formula { get; set; } = string.Empty;

    ///     Width of the field in pixels
    [JsonProperty("width")]
    public double Width { get; set; }

    ///     Whether the field is hidden
    [JsonProperty("isHidden")]
    public bool IsHidden { get; set; }

    ///     Horizontal alignment (Left, Center, Right)
    [JsonProperty("horizontalAlignment")]
    public string HorizontalAlignment { get; set; } = "Left";

    ///     Format option (e.g. DUT_METERS for length, or custom format string)
    [JsonProperty("formatOption")]
    public string FormatOption { get; set; } = string.Empty;

    ///     Accuracy for numeric fields
    [JsonProperty("accuracy")]
    public int? Accuracy { get; set; }

    ///     Use thousand separator for numeric fields
    [JsonProperty("useThousandSeparator")]
    public bool? UseThousandSeparator { get; set; }
}

///     Information about a schedule filter
public class ScheduleFilterInfo
{
    ///     Field name to filter by
    [JsonProperty("fieldName")]
    public string FieldName { get; set; } = string.Empty;

    ///     Field index to filter by (alternative to name)
    [JsonProperty("fieldIndex")]
    public int FieldIndex { get; set; } = -1;

    ///     Filter type (Equals, NotEquals, GreaterThan, etc.)
    [JsonProperty("filterType")]
    public string FilterType { get; set; } = "Equal";

    ///     Filter value
    [JsonProperty("filterValue")]
    public string FilterValue { get; set; } = string.Empty;
}

///     Information about schedule sorting
public class ScheduleSortInfo
{
    ///     Field name to sort by
    [JsonProperty("fieldName")]
    public string FieldName { get; set; } = string.Empty;

    ///     Field index to sort by (alternative to name)
    [JsonProperty("fieldIndex")]
    public int FieldIndex { get; set; } = -1;

    ///     Sort order (Ascending, Descending)
    [JsonProperty("sortOrder")]
    public string SortOrder { get; set; } = "Ascending";
}

///     Information about schedule grouping
public class ScheduleGroupInfo
{
    ///     Field name to group by
    [JsonProperty("fieldName")]
    public string FieldName { get; set; } = string.Empty;

    ///     Field index to group by (alternative to name)
    [JsonProperty("fieldIndex")]
    public int FieldIndex { get; set; } = -1;

    ///     Sort order (Ascending, Descending)
    [JsonProperty("sortOrder")]
    public string SortOrder { get; set; } = "Ascending";

    ///     Show header for group
    [JsonProperty("showHeader")]
    public bool ShowHeader { get; set; } = true;

    ///     Show footer for group
    [JsonProperty("showFooter")]
    public bool ShowFooter { get; set; }

    ///     Show blank line after group
    [JsonProperty("showBlankLine")]
    public bool ShowBlankLine { get; set; }

    ///     Format data for headers/footers
    [JsonProperty("formatData")]
    public string FormatData { get; set; } = string.Empty;
}
