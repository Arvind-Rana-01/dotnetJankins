using System.ComponentModel.DataAnnotations;

namespace ToolMonitoringServices.Model
{
    public class GetAdmin
    {
        //public int Id { get; set; }
        [Key]
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; }= string.Empty;
    }
}
