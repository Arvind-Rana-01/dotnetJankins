using System.ComponentModel.DataAnnotations;

namespace ToolMonitoringServices.Model
{
    public class ToolMaster
    {
        [Key]
        public Guid ToolID { get; set; }
        public string ToolName { get; set; } = string.Empty;
        public string ToolDescription { get; set; } = string.Empty;
        public Guid RegionID { get; set; }
        public Guid ToolCategoryID { get; set; }
        public string PartsProduce { get; set; } = string.Empty;
        public string NumberofPartsPerStroke { get; set; } = string.Empty;
        public string StrokeCount { get; set; } = string.Empty;
        public string ExpectedUsefulLife { get; set; } = string.Empty;
        public Guid ConditionID { get; set; }
        public byte[]? ToolImage { get; set; }

        public Guid LocID { get; set; }

       /* public DateTime DateAdded { get; set; }
        public int AddedBy { get; set; }
        public DateTime DateChanged { get; set; }
        public int ChangedBy { get; set; }*/
    }
}
