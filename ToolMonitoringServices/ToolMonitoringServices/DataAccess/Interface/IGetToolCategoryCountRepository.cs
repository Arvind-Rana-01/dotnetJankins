using ToolMonitoringServices.Model;

namespace ToolMonitoringServices.DataAccess.Interface
{
    public interface IGetToolCategoryCountRepository
    {
        Task<List<ToolCategories>> GetToolCategory();
    }
}
