using ToolMonitoringServices.DataAccess.Interface;
using ToolMonitoringServices.Model;

namespace ToolMonitoringServices.DataAccess.Repository
{
    public class GetToolDetailsRepository : IGetToolDetailsRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<GetToolDetailsRepository> _logger; // Logger instance

        public GetToolDetailsRepository(AppDbContext context, ILogger<GetToolDetailsRepository> logger)
        {
            _context = context;
            _logger = logger; // Initialize the logger
        }

        public async Task<List<ToolMaster>> GetToolDetail()
        {
            try
            {
                _logger.LogInformation("Starting to retrieve tool details"); // Log information
                List<ToolMaster> GetAllDetails =  _context.ToolMaster
                    //.Where(t => t.ToolID == id)
                    .Select(r => new ToolMaster
                    {
                        ToolID = r.ToolID,
                        ToolCategoryID = r.ToolCategoryID,
                        ToolName = r.ToolName,
                        ToolDescription = r.ToolDescription,
                        PartsProduce = r.PartsProduce,
                        NumberofPartsPerStroke = r.NumberofPartsPerStroke,
                        StrokeCount = r.StrokeCount,
                        ExpectedUsefulLife = r.ExpectedUsefulLife,
                        ToolImage = r.ToolImage
                    }).ToList();

                _logger.LogInformation($"Retrieved {GetAllDetails.Count} tool details"); // Log success
                return GetAllDetails;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving tool details"); // Log error
                throw; // Re-throw the exception to maintain the stack trace.
            }
        }
    }
}
