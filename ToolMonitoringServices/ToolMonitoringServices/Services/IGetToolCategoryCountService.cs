using ToolMonitoringServices.Model;

namespace ToolMonitoringServices.Services
{
    public interface IGetToolCategoryCountService
    {
        Task<List<ToolCategories>> GetToolCategory();
    }
}
