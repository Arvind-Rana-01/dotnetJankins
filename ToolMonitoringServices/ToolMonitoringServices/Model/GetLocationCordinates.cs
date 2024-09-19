namespace ToolMonitoringServices.Model
{
    public class GetLocationCordinates
    {

        public Guid Id { get; set; }
        public string Options { get; set; }
        public List<GetPointsModel> GetPoints { get; set; }
    }
    public class GetPointsModel
    {
        public Guid ToolId { get; set; }
        public string LocationName { get; set; }
        public string Status { get; set; }
        public string partsProduce { get; set; }
        public string Partsper1Stroke { get; set; }
        public string expectedUsefulLife { get; set; }
        public string regionName { get; set; }
        public GetLocat Location { get; set; }
    }
    public class GetLocat
    {
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
    }
  

}
