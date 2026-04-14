using blog.Dtos.Page;

namespace blog.Dtos
{
    public class PostDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required string CreateUserName { get; set; }
        public required DateTime CreateDate { get; set; }
    }

    public class PostRequestDto : PageQueryDto
    {
        public string? Title { get; set; }
    }

    public class CreatePostDto
    {
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required int CreateUserId { get; set; }
    }

    public class UpdatePostDto : CreatePostDto
    {
        public required int Id { get; set; }
    }
}
