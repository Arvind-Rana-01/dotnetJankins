using ToolMonitoringServices.Model;

namespace ToolMonitoringServices.DataAccess.Interface
{
    
        public interface IGetToolHierarchyRepository
        {
            Task<List<Node>> GetHierarchy(string toolid);

        //Task<List<Node>> GetNodes();
        }

   
    
}
