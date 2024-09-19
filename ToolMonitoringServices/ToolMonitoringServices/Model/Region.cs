using System.ComponentModel.DataAnnotations;

namespace ToolMonitoringServices.Model
{
    public class Region
    {
            [Key]
            public Guid RegionID { get; set; }
            public string RegionName { get; set; } = string.Empty;     
    }
}
