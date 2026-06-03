namespace blog.Entities.Flows
{
    public class FlowRule
    {
        public int Id { get; set; }
        public Guid FlowNodeId { get; set; }
        public string? ConditionJson { get; set; }
        public string? ActionJson { get; set; }
        public int Sort { get; set; }
        public FlowNode FlowNode { get; set; }
    }
}
