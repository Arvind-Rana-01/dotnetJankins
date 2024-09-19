using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ToolMonitoringServices.Model
{
    /*public class MindMapNodeList
    {

        [JsonIgnore]
        public int Id { get; set; }
        public List<Node> Nodes { get; set; }
    }*/

    public class Node
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
}
