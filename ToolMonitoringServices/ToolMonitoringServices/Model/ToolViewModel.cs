using System.ComponentModel.DataAnnotations;

namespace ToolMonitoringServices.Model
{
    public class ToolViewModel
    {
        [Key]
        public Guid ToolCategoryID { get; set; }
        public Guid RegionID { get; set; }   
        public string RegionName { get; set; } = string.Empty;
        public string ToolCategoryName { get; set; } = string.Empty;
        public Guid id { get; set; }
        public string ToolName { get; set; } = string.Empty;
        public string PartsProduce { get; set; } = string.Empty;
        public string ExpectedUsefulLife { get; set; } = string.Empty;
        public Byte[]? ToolImage {  get; set; }
        public string Base64ToolImage { get; set; }
        public string NumberofPartsPerStroke { get; set; } = string.Empty;
        public string StrokeCount { get; set; } = string.Empty;
        public ToolMaster ToolDetails { get; set; }
    }
}
