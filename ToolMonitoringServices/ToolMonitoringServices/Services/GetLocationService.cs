using ToolMonitoringServices.DataAccess.Interface;
using ToolMonitoringServices.Model;

namespace ToolMonitoringServices.Services
{
    public class GetLocationService :IGetLocationService
    {
        private readonly IGetLocationRepository _joinRepository;
        private readonly ILogger<GetLocationService> _logger; // Declare a logger
        public GetLocationService(IGetLocationRepository joinRepository, ILogger<GetLocationService> logger)
        {
            _joinRepository = joinRepository;
            _logger = logger;
        }
        public async Task<List<GetLocationCordinates>> GetLocations()
        {
            try
            {
                //return await _joinRepository.GetLocation();
                _logger.LogInformation("Starting to get categories");
                var result = await _joinRepository.GetLocations();
                _logger.LogInformation($"Categories obtained: {result.Count}");
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting Categories");
                throw; // Re-throw the exception to maintain the stack trace.
            }
        }
    }
}
