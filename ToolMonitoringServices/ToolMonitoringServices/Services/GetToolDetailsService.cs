using ToolMonitoringServices.DataAccess.Interface;
using ToolMonitoringServices.Model;

namespace ToolMonitoringServices.Services
{
    public class GetToolDetailsService : IGetToolDetailsService
    {
        private readonly IGetToolDetailsRepository _joinRepository;
        private readonly ILogger<GetToolDetailsService> _logger; // Logger instance

        public GetToolDetailsService(IGetToolDetailsRepository joinRepository, ILogger<GetToolDetailsService> logger)
        {
            _joinRepository = joinRepository;
            _logger = logger; // Initialize the logger
        }

        public async Task<List<ToolMaster>> GetToolDetail()
        {
            _logger.LogInformation("GetToolDetail method called."); // Log information
            var toolDetails = await _joinRepository.GetToolDetail();
            _logger.LogInformation($"Number of tool details retrieved: {toolDetails.Count}"); // Log success
            return toolDetails;
        }
    }
}
