using ToolMonitoringServices.Model;

namespace ToolMonitoringServices.Services
{
    public interface IGetToolListService
    {
        Task<List<ToolViewModel>> GetTools(string category, string search, string region);

        //Task<List<ToolViewModel>> GetToolsByCategoryName(string category);
    }
}
