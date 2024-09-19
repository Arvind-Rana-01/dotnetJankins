using System.ComponentModel.DataAnnotations;

namespace ToolMonitoringServices.Model
{

    public class ToolHierarchyModel
    {
        [Key]
        public string RegionName { get; set; } = string.Empty;
       // public List<Node> Nodes { get; set; }
        //public required List<SupplierModel> Suppliers { get; set; }
    }

    /*public class SupplierModel
    {
        [Key]
        public string SupplierName { get; set; } = string.Empty;
        public string ConditionName { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public int Source {  get; set; }
        public int Target { get; set; }

        public 
    }*/
    /*public class Node
    {
        [Key]
        public string Id { get; set; }
        public string Type { get; set; }
        public NodeData Data { get; set; }
    }

    public class NodeData
    {
        [Key]
        public string Label { get; set; }
        public string Condition { get; set; }
        public List<Edge> Edges { get; set; }
    }

    public class Edge
    {
        [Key]
        public string target { get; set; }
    }
*/
}
