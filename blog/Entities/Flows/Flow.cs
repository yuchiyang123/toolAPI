using blog.Entities.User;

namespace blog.Entities.Flows
{
    public class Flow
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required DateTime UpdateDate { get; set; }
        public required int UpdateUser { get; set; }
        public required DateTime CreateDate { get; set; }
        public required int CreateUser { get; set; }
        public ICollection<FlowVersion> FlowVersion { get; set; }
        public Users UpdateUsers { get; set; }
        public Users CreateUsers { get; set; }
    }
}
