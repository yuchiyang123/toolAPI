using blog.Entities.User;

namespace blog.Entities.Flows
{
    public class FlowNode
    {
        public Guid Id { get; set; }
        public int FlowVersionId { get; set; }
        public required string StageName { get; set; }
        public int Type { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public required DateTime UpdateDate { get; set; }
        public required int UpdateUser { get; set; }
        public required DateTime CreateDate { get; set; }
        public required int CreateUser { get; set; }
        public FlowVersion FlowVersion { get; set; }
        public ICollection<FlowEdge> FlowEdges { get; set; }
        public ICollection<FlowRule> FlowRules { get; set; }
        public Users UpdateUsers { get; set; }
        public Users CreateUsers { get; set; }
    }
}
