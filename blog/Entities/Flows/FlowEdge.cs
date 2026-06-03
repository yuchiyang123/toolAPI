using blog.Entities.User;

namespace blog.Entities.Flows
{
    public class FlowEdge
    {
        public int Id { get; set; }
        public int FlowVersionId { get; set; }
        public Guid SourceNodeId { get; set; }
        public Guid TargetNodeId { get; set; }
        public string? DataJson { get; set; }
        public required DateTime UpdateDate { get; set; }
        public required int UpdateUser { get; set; }
        public required DateTime CreateDate { get; set; }
        public required int CreateUser { get; set; }
        public FlowVersion FlowVersion { get; set; }
        public FlowNode FlowSourceNode { get; set; }
        public FlowNode FlowTargetNode { get; set; }
        public Users UpdateUsers { get; set; }
        public Users CreateUsers { get; set; }
    }
}
