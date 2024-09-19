using ToolMonitoringServices.DataAccess.Repository;
using ToolMonitoringServices.Model;

namespace ToolMonitoringServices.DataAccess.Interface
{
    public interface IGetLocationRepository
    {
        Task<List<GetLocationCordinates>> GetLocations();
    }
}
