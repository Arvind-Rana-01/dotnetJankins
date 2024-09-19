using ToolMonitoringServices.DataAccess.Interface;
using ToolMonitoringServices.DataAccess;
using ToolMonitoringServices.Model;

namespace ToolMonitoringServices.Services
{
        public class GetToolListService : IGetToolListService
        {
        private readonly IGetToolListRepository _joinRepository;
        private readonly ILogger<GetToolListService> _logger; // Logger instance

        public GetToolListService(IGetToolListRepository joinRepository, ILogger<GetToolListService> logger)
        {
            _joinRepository = joinRepository;
            _logger = logger; // Initialize the logger
        }

        public async Task<List<ToolViewModel>> GetTools(string category,string search, string region )
        {
            _logger.LogInformation("GetTools method called."); // Log information
            var toolList = await _joinRepository.GetTools(category,search,region);
            _logger.LogInformation($"Number of tools retrieved: {toolList.Count}"); // Log success
            return toolList;
        }

    }
}
