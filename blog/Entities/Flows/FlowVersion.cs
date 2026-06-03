using blog.Entities.User;

namespace blog.Entities.Flows
{
    public class FlowVersion
    {
        public int Id { get; set; }
        public int FlowId { get; set; }
        public required string Version { get; set; }
        public bool IsActive { get; set; }
        public required DateTime UpdateDate { get; set; }
        public required string UpdateUser { get; set; }
        public required DateTime CreateDate { get; set; }
        public required string CreateUser { get; set; }
        public Flow Flows { get; set; }
        public ICollection<FlowNode> FlowNodes { get; set; }
        public ICollection<FlowEdge> FlowEdges { get; set; }
        public Users UpdateUsers { get; set; }
        public Users CreateUsers { get; set; }
    }
}
