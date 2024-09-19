using System.ComponentModel.DataAnnotations;

namespace ToolMonitoringServices.Model
{
    public class ToolCategories
    {
        [Key]
        public Guid ToolCategoryID { get; set; }
        public string ToolCategoryName { get; set; } = string.Empty;

        public Guid LocID { get; set; }
        //public string StrokeCount { get; set; } = string.Empty;
    }
}
                