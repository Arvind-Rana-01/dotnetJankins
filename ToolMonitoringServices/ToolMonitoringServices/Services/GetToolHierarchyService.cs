using ToolMonitoringServices.DataAccess.Interface;
using ToolMonitoringServices.Model;

namespace ToolMonitoringServices.Services
{
    public class GetToolHierarchyService : IGetToolHierarchyService
    {
        private readonly IGetToolHierarchyRepository _joinRepository;
        private readonly ILogger<GetToolHierarchyService> _logger; // Logger instance

        public GetToolHierarchyService(IGetToolHierarchyRepository joinRepository, ILogger<GetToolHierarchyService> logger)
        {
            _joinRepository = joinRepository;
            _logger = logger; // Initialize the logger
        }

        public async Task<List<Node>> GetHierarchy(string toolId)
        {
            try
            {
                _logger.LogInformation("GetHierarchy method called."); // Log information
                var hierarchyItems = await _joinRepository.GetHierarchy(toolId);
                _logger.LogInformation($"Number of hierarchy items retrieved: {hierarchyItems.Count}"); // Log success
                return hierarchyItems;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting tool heirarchy"); // Log error
                throw; // Re-throw the exception to maintain the stack trace.
            }
        }
    }
}
