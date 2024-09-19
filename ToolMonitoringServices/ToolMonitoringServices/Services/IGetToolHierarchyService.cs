using ToolMonitoringServices.Model;

namespace ToolMonitoringServices.Services
{
    public interface IGetToolHierarchyService
    {
        Task<List<Node>> GetHierarchy(string toolId);
    }
}
