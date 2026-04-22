namespace blog.Entities.Blog
{
    public class PostsTag
    {
        public int Id { get; set; }
        public int FK_PostsId { get; set; }
        public required string Tag { get; set; }
        public Posts Posts { get; set; }
    }
}
