using ToolMonitoringService.DataAccess.Repository;
using ToolMonitoringServices.DataAccess.Interface;
using ToolMonitoringServices.Model;

namespace ToolMonitoringServices.Services
{
    public class GetCategoriesService : IGetCategoriesService
    {
        private readonly IGetCategoriesRepository _joinRepository;
        private readonly ILogger<GetCategoriesService> _logger; // Declare a logger
        public GetCategoriesService(IGetCategoriesRepository joinRepository, ILogger<GetCategoriesService> logger)
        {
            _joinRepository = joinRepository;
            _logger = logger;
        }

        public async Task<List<ToolCategories>> GetCategory()
        {
            try {
                //return await _joinRepository.GetCategory();
                _logger.LogInformation("Starting to get categories");
                var result = await _joinRepository.GetCategory();
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
