using ToolMonitoringServices.Model;

namespace ToolMonitoringServices.DataAccess.Interface
{
    public interface IGetRegionsRepository
    {
        Task<List<Region>> GetRegion();
    }
}
