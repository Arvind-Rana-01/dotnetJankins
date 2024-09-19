using Microsoft.EntityFrameworkCore;
using ToolMonitoringService.DataAccess.Repository;
using ToolMonitoringServices.Controllers;
using ToolMonitoringServices.DataAccess.Interface;
using ToolMonitoringServices.Model;

namespace ToolMonitoringServices.DataAccess.Repository
{
    public class GetLocationRepository : IGetLocationRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<GetLocationRepository> _logger;

        public GetLocationRepository(AppDbContext context, ILogger<GetLocationRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        
        public async Task<List<GetLocationCordinates>> GetLocations()
        {
            var result = await (from ct in _context.ToolCategories
                                join tool in _context.ToolMaster on ct.ToolCategoryID equals tool.ToolCategoryID
                                join loc in _context.GetLocationByPin on tool.LocID equals loc.LocID
                                join tc in _context.ToolConditionMaster on tool.ConditionID equals tc.ConditionID
                                join r in _context.Region on tool.RegionID equals r.RegionID
                                select new
                                {
                                    ct.ToolCategoryID,
                                    ct.ToolCategoryName,
                                    tool.ToolID,
                                    tool.PartsProduce,
                                    tool.NumberofPartsPerStroke,
                                    tool.ExpectedUsefulLife,    
                                    loc.LocationName,
                                    tc.ConditionName,
                                    loc.Longitude,
                                    loc.Latitude,
                                    tool.ToolName,
                                    r.RegionName
                                    
                                }).ToListAsync();

            List<GetLocationCordinates> categoryList = new List<GetLocationCordinates>();

            foreach (var item in result.GroupBy(i => new { i.ToolCategoryID, i.ToolCategoryName }))
            {
                GetLocationCordinates category = new GetLocationCordinates
                {
                    Id = item.Key.ToolCategoryID,
                    Options = item.Key.ToolCategoryName,
                    GetPoints = item.Select(i => new GetPointsModel
                    {
                        ToolId = i.ToolID,
                        LocationName = i.LocationName,
                        Status = i.ConditionName,
                        partsProduce = i.PartsProduce,
                        Partsper1Stroke=i.NumberofPartsPerStroke,
                        expectedUsefulLife=i.ExpectedUsefulLife,
                        regionName=i.RegionName,
                        Location = new GetLocat
                        {
                            latitude = i.Latitude,
                            longitude = i.Longitude
                        }
                    }).ToList()
                };

                categoryList.Add(category);
            }

            return categoryList;
        }

    }

}

