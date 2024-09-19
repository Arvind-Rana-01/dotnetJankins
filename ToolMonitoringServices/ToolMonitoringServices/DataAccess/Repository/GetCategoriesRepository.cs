using ToolMonitoringServices.DataAccess.Interface;
using ToolMonitoringServices.Model;
using ToolMonitoringServices.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;

namespace ToolMonitoringService.DataAccess.Repository
{
    public class GetCategoriesRepository : IGetCategoriesRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<GetCategoriesRepository> _logger;

        public GetCategoriesRepository(AppDbContext context, ILogger<GetCategoriesRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<ToolCategories>> GetCategory()
        {
            try
            {
                _logger.LogInformation("Starting to get Category");
                List<ToolCategories> categoryNames =  _context.ToolCategories
               .Select(r => new ToolCategories
               {
                   ToolCategoryName = r.ToolCategoryName,
                   ToolCategoryID = r.ToolCategoryID
               })
               .ToList();
                _logger.LogInformation("Successfully retrieved.");
                return categoryNames;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving.");
                throw; // Rethrow the exception to handle it further up the call stack.
            }
        }
    }
}


