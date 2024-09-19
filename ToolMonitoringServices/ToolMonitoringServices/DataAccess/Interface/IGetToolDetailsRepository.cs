using ToolMonitoringServices.Model;

namespace ToolMonitoringServices.DataAccess.Interface
{
    public interface IGetToolDetailsRepository
    {
        Task<List<ToolMaster>> GetToolDetail();
    }
}
