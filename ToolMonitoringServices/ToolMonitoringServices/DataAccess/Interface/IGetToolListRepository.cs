using ToolMonitoringServices.Model;

namespace ToolMonitoringServices.DataAccess.Interface
{
        public interface IGetToolListRepository
        {
            Task<List<ToolViewModel>> GetTools(string category, string search, string region);

            //Task<List<ToolViewModel>> GetToolsByCategoryName(string category);
        }
}
