using System;
using ToolMonitoringServices.DataAccess.Interface;
using System.Linq.Expressions;
using ToolMonitoringServices.Model;
using Microsoft.EntityFrameworkCore;

namespace ToolMonitoringServices.DataAccess.Repository
{
    public class GetRegionsRepository : IGetRegionsRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<GetRegionsRepository> _logger;

        public GetRegionsRepository(AppDbContext context, ILogger<GetRegionsRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Region>> GetRegion()
        {
            try {
                _logger.LogInformation("Starting to get regions");


                List<Region> regionNames = await _context.Region
                   .Select(r => new Region { RegionName = r.RegionName })
                   .OrderBy(r => r.RegionName != "All") // "ALL" will appear first
                   .ThenBy(r => r.RegionName != "Americas")
                   .ThenBy(r => r.RegionName != "APAC")
                   .ThenBy(r => r.RegionName != "EMEA")
                   .ToListAsync();

                _logger.LogInformation($"Regions obtained: {regionNames.Count}");
                return regionNames;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting regions"); // Log error
                throw; // Re-throw the exception to maintain the stack trace.
            }
            }
    }
}
