using System.ComponentModel.DataAnnotations;

namespace ToolMonitoringServices.Model
{
    public class ToolConditionMaster
    {
        [Key]
        public Guid ConditionID { get; set; }
        public string ConditionName { get; set; } = string.Empty;
        public DateTime DateAdded { get; set; }
        public int AddedBy { get; set; }
        public DateTime DateChanged { get; set; }
        public int ChangedBy { get; set; }

    }
}
