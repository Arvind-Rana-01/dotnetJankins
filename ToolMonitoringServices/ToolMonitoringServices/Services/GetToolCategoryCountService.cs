using ToolMonitoringServices.DataAccess.Interface;
using ToolMonitoringServices.Model;

namespace ToolMonitoringServices.Services
{
    public class GetToolCategoryCountService : IGetToolCategoryCountService
    {
        private readonly IGetToolCategoryCountRepository _joinRepository;
        private readonly ILogger<GetToolCategoryCountService> _logger; // Logger instance

        public GetToolCategoryCountService(IGetToolCategoryCountRepository joinRepository, ILogger<GetToolCategoryCountService> logger)
        {
            _joinRepository = joinRepository;
            _logger = logger; // Initialize the logger
        }

        public async Task<List<ToolCategories>> GetToolCategory()
        {
            _logger.LogInformation("GetToolCategory method called."); // Log information

            var toolCategories = await _joinRepository.GetToolCategory();

            _logger.LogInformation($"Number of tool categories retrieved: {toolCategories.Count}"); // Log success
            return toolCategories;
        }
    }
}
