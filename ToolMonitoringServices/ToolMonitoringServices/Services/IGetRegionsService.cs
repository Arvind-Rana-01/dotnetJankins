using ToolMonitoringServices.Model;

namespace ToolMonitoringServices.Services
{
    public interface IGetRegionsService
    {
       Task<List<Region>> GetRegion();
    }
}
