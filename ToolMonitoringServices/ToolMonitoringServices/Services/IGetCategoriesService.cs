using ToolMonitoringServices.Model;

namespace ToolMonitoringServices.Services
{
    public interface IGetCategoriesService
    {
        Task<List<ToolCategories>> GetCategory();
    }
}
