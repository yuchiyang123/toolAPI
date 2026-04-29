namespace blog.Entities.Blog
{
    public class PostsTagMapping
    {
        public int Id { get; set; }
        public int FK_PostsId { get; set; }
        public int FK_TagId { get; set; }
        public Posts Posts { get; set; }
        public PostsTag PostsTag { get; set; }
    }
}
