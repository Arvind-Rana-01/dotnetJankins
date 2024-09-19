using ToolMonitoringServices.Model;
using ToolMonitoringService.DataAccess;

namespace ToolMonitoringServices.DataAccess.Interface
{
    public interface IGetCategoriesRepository
    {
        Task<List<ToolCategories>> GetCategory();
    }
}
