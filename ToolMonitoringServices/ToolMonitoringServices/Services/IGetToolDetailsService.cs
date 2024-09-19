using ToolMonitoringServices.Model;

namespace ToolMonitoringServices.Services
{
    public interface IGetToolDetailsService
    {
        Task<List<ToolMaster>> GetToolDetail();
    }
}
