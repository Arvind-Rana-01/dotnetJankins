using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using ToolMonitoringServices.DataAccess.Interface;
using ToolMonitoringServices.Model;

namespace ToolMonitoringServices.DataAccess.Repository
{
    public class GetToolHierarchyRepository : IGetToolHierarchyRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<GetToolHierarchyRepository> _logger; // Logger instance

        public GetToolHierarchyRepository(AppDbContext context, ILogger<GetToolHierarchyRepository> logger)
        {
            _context = context;
            _logger = logger; // Initialize the logger
        }


        public async Task<List<Node>> GetHierarchy(string toolId)
        {
            try
            {
                _logger.LogInformation("Starting to retrieve tool hierarchy");

                //var nodeIds = new Dictionary<string, int>();
                Guid s = Guid.Parse(toolId);
                Console.WriteLine(s);
                var query = await (
                from region in _context.Region
                join supplier in _context.SupplierMaster on region.RegionID equals supplier.RegionID
                join assessment in _context.ToolSupplierAssessment on supplier.SupplierID equals assessment.SupplierID
                join tool in _context.ToolMaster on assessment.ToolID equals tool.ToolID
                join condition in _context.ToolConditionMaster on tool.ConditionID equals condition.ConditionID
                where assessment.ToolID == s
                select new
                {
                    RegionName = region.RegionName,
                    SupplierName = supplier.SupplierName,
                    ConditionName = condition.ConditionName
                }).ToListAsync();

                var nodes = new List<Node>();

                // Create the initial node for "Insulted at which Suppliers"
                var insultedNode = new Node
                {
                    Id = "1",
                    Type = "input",
                    Data = new NodeData
                    {
                        Label = "Insulted at which Suppliers",
                        Edges = new List<Edge>()
                    }
                };

                nodes.Add(insultedNode);

                int nodeIdCounter = 2; // Start node id from 2

                var regionNodes = new Dictionary<string, Node>();

                foreach (var item in query)
                {
                    if (!regionNodes.ContainsKey(item.RegionName))
                    {
                        var regionNode = new Node
                        {
                            Id = nodeIdCounter.ToString(),
                            Data = new NodeData
                            {
                                Label = item.RegionName,
                                Condition = "place",
                                Edges = new List<Edge>()
                            }
                        };

                        nodes.Add(regionNode);
                        insultedNode.Data.Edges.Add(new Edge { target = regionNode.Id });
                        regionNodes[item.RegionName] = regionNode;
                        nodeIdCounter++;
                    }

                    var supplierNode = new Node
                    {
                        Id = nodeIdCounter.ToString(),
                        Data = new NodeData
                        {
                            Label = $"{item.SupplierName} | Condition= {item.ConditionName}",
                            Condition = item.ConditionName.ToLower(),
                            Edges = new List<Edge>()
                        }
                    };

                    regionNodes[item.RegionName].Data.Edges.Add(new Edge { target = supplierNode.Id });
                    nodes.Add(supplierNode);
                    nodeIdCounter++;
                }

                _logger.LogInformation($"Retrieved {nodes.Count} tool hierarchy items");
                return nodes;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while getting tool heirarchy "); // Log error
                throw; // Re-throw the exception to maintain the stack trace.
            }
        }
    }
}