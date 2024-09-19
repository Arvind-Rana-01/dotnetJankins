using System.ComponentModel.DataAnnotations;

namespace ToolMonitoringServices.Model
{
    public class ToolSupplierAssessment
    {
        [Key]
        public Guid AssessmentID { get; set; }
        public Guid SupplierID { get; set; }
        public Guid ToolID { get; set; }
        public DateTime AssessmentDate { get; set; }
        public int AssessmentYear { get; set; }
        public int AssessmentMonth { get; set; }
        public DateTime DateAdded { get; set; }
        public int AddedBy { get; set; }
        public DateTime DateChanged { get; set; }
        public int ChangedBy { get; set; }
    }
}

