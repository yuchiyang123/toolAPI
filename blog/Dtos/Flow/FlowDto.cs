using blog.Dtos.Page;

namespace blog.Dtos.Flow
{
    public class ConditionGroup
    {
        public required string Operator { get; set; }
        public List<ConditionLeaf>? Leaves { get; set; }
        public List<ConditionGroup>? Groups { get; set; }
    }

    public class ConditionLeaf
    {
        public required string Field { get; set; }
        public required string Op { get; set; }
        public required string Value { get; set; }
    }

    public class Action
    {
        public required int Type { get; set; }
        public required int TargetUser { get; set; }
        public string? Message { get; set; }
    }

    public class FlowList
    {
        public int Id { get; set; }
        public required string FlowName { get; set; }
        public required string Description { get; set; }
        public string? FlowActionVersion { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CreateDate { get; set; }
        public required UserDto UpdateUserData { get; set; }
        public required UserDto CreateUserData { get; set; }
        public List<FlowVersionList> FlowVersionList { get; set; } = [];
    }

    public class FlowVersionList
    {
        public int VersionId { get; set; }
        public required string FlowVersion { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CreateDate { get; set; }
        public required UserDto UpdateUserData { get; set; }
        public required UserDto CreateUserData { get; set; }
    }

    public class FlowDetailsRequestDto : FlowDetailBaseDto
    {
        public int FlowId { get; set; }
    }

    public class FlowDetailResponseDto : FlowDetailsRequestDto
    {
        public int VersionId { get; set; }
    }

    public class FlowDetailBaseDto
    {
        public required string FlowVersion { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CreateDate { get; set; }
        public required UserDto UpdateUserData { get; set; }
        public required UserDto CreateUserData { get; set; }
        public List<FlowNodeDto> Nodes { get; set; } = [];
        public List<FlowEdgeDto> Edges { get; set; } = [];
    }

    public class FlowNodeDto
    {
        public Guid Id { get; set; }
        public required string StageName { get; set; }
        public int Type { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public List<FlowRuleDto> Rules { get; set; } = [];
    }

    public class FlowEdgeDto
    {
        public Guid Id { get; set; }
        public Guid SourceNodeId { get; set; }
        public Guid TargetNodeId { get; set; }
        public ConditionGroup? Condition { get; set; }
    }

    public class FlowRuleDto
    {
        public int Id { get; set; }
        public int Sort { get; set; }
        public ConditionGroup? Condition { get; set; }
        public Action? Action { get; set; }
    }

    public class FlowListQueryDto : PageDto
    {
        public string? FlowName { get; set; }
    }

    public class CreateFlowDto
    {
        public required string FlowName { get; set; }
        public string? Description { get; set; }
    }
}
