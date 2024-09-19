using System.ComponentModel.DataAnnotations;

namespace ToolMonitoringServices.Model
{
    public class SupplierMaster
    {
        [Key]
        public Guid SupplierID { get; set; }
        public Guid RegionID { get; set; }
        public string SupplierName { get; set; } = string.Empty;

        //public string SupplierAddress { get; set; } = string.Empty;
        //public int SupplierContact { get; set; }
        //public string SupplierLatitude { get; set; } = string.Empty;
        //public string SupplierLongitude { get; set; } = string.Empty;
        //public DateTime DateAdded { get; set; }
        //public int AddedBy { get; set; }
        //public DateTime DateChanged { get; set; }
        //public int ChangedBy { get; set; }
    }

    /*public class MindMapNodeList
    {
        public List<MindMapNode> MindMapNodes { get; set; }
    }
*/
   
}
