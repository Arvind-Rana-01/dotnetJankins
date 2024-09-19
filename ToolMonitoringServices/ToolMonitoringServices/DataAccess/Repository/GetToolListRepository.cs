using Microsoft.EntityFrameworkCore;
using ToolMonitoringServices.DataAccess.Interface;
using ToolMonitoringServices.Model;
using ToolMonitoringServices.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace ToolMonitoringServices.DataAccess.Repository
{
    public class GetToolListRepository : IGetToolListRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<GetToolListRepository> _logger; // Logger instance


        public GetToolListRepository(AppDbContext context, ILogger<GetToolListRepository> logger)
        {
            _context = context;
            _logger = logger; // Initialize the logger
        }

        public async Task<List<ToolViewModel>> GetTools(string category, string search, string region)
        {
            try
            {
                _logger.LogInformation("Starting to retrieve tool list"); // Log information
                //if (string.IsNullOrEmpty(category) && string.IsNullOrEmpty(search) && string.IsNullOrEmpty(region))
                
                    var tools = (from t1 in _context.ToolCategories
                                 join t2 in _context.ToolMaster on t1.ToolCategoryID equals t2.ToolCategoryID
                                 join t3 in _context.Region on t2.RegionID equals t3.RegionID
                                 select new ToolViewModel
                                 {
                                     id = t2.ToolID,
                                     ToolName = t2.ToolName,
                                     ToolCategoryID = t2.ToolCategoryID,
                                     ToolCategoryName = t1.ToolCategoryName,
                                     PartsProduce = t2.PartsProduce,
                                     ExpectedUsefulLife = t2.ExpectedUsefulLife,
                                     NumberofPartsPerStroke=t2.NumberofPartsPerStroke,
                                     StrokeCount=t2.StrokeCount,
                                     RegionName = t3.RegionName,
                                     ToolImage= t2.ToolImage
                                     
                                 }).ToList();

                

                if (!string.IsNullOrEmpty(category))
                {
                    tools = tools.Where(t => t.ToolCategoryName == category).ToList();
                }

                if (!string.IsNullOrEmpty(search))
                {
                    tools = tools.Where(t => t.ToolName.Contains(search)).ToList();
                }

                if (!string.IsNullOrEmpty(region))
                {
                    tools = tools.Where(t => t.RegionName == region).ToList();
                }

                var toolList =  tools.ToList();

                _logger.LogInformation($"Retrieved {tools.Count} tools"); // Log success
                return toolList.Select(t => new ToolViewModel
                {
                    ToolName = t.ToolName,
                    id=t.id,
                    ToolCategoryID = t.ToolCategoryID,
                    ToolCategoryName = t.ToolCategoryName,
                    PartsProduce = t.PartsProduce,
                    ExpectedUsefulLife = t.ExpectedUsefulLife,
                    RegionName=t.RegionName,
                    NumberofPartsPerStroke = t.NumberofPartsPerStroke,
                    StrokeCount = t.StrokeCount,
                    //ToolImage=t.ToolImage,
                    //Base64ToolImage = Convert.ToBase64String(t.ToolImage)
                }).ToList();
            }
            
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving tool list"); // Log error
                throw; // Re-throw the exception to maintain the stack trace.
            }
        } 
    }
}
