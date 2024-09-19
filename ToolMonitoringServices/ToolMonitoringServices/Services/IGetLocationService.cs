using ToolMonitoringServices.Model;

namespace ToolMonitoringServices.Services
{
    public interface IGetLocationService
    {
        Task<List<GetLocationCordinates>> GetLocations();
    }
}
