using ToolMonitoringServices.Model;
using ToolMonitoringServices.DataAccess.Interface;

namespace ToolMonitoringServices.Services
{
    public class GetRegionsService : IGetRegionsService
    {

        private readonly IGetRegionsRepository _joinRepository;
        private readonly ILogger<GetRegionsService> _logger;

        public GetRegionsService(IGetRegionsRepository joinRepository, ILogger<GetRegionsService> logger)
        {
            _joinRepository = joinRepository;
            _logger = logger;
        }


        public async Task<List<Region>> GetRegion()
        {
            try
            {
                _logger.LogInformation("Starting to get regions");
                List<Region> regionNames = await _joinRepository.GetRegion();
                _logger.LogInformation($"Regions obtained: {regionNames.Count}");
                return regionNames;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting regions");
                throw; // Re-throw the exception to maintain the stack trace.
            }
        }

    }
}
