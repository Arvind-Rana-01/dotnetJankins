using Microsoft.EntityFrameworkCore;
using ToolMonitoringServices.DataAccess.Interface;
using ToolMonitoringServices.Model;

namespace ToolMonitoringServices.DataAccess.Repository
{
    public class GetToolCategoryCountRepository : IGetToolCategoryCountRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<GetToolCategoryCountRepository> _logger; // Logger instance

        public GetToolCategoryCountRepository(AppDbContext context, ILogger<GetToolCategoryCountRepository> logger)
        {
            _context = context;
            _logger = logger; // Initialize the logger
        }

        public async Task<List<ToolCategories>> GetToolCategory()
        {
            try
            {
                _logger.LogInformation("Starting to get tool categories"); // Log information
                var query = from tool in _context.ToolMaster
                            join category in _context.ToolCategories on tool.ToolCategoryID equals category.ToolCategoryID
                            select new ToolCategories
                            {
                                ToolCategoryName = category.ToolCategoryName,
                                //StrokeCount = tool.StrokeCount
                            };

                var result = await Task.FromResult(query.ToList());

                _logger.LogInformation($"Tool categories obtained: {result.Count}"); // Log success
                return result;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting tool categories"); // Log error
                throw; // Re-throw the exception to maintain the stack trace.
            }
        }
    }
}
