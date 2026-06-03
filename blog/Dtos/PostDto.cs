using blog.Dtos.Page;

namespace blog.Dtos
{
    public class PostDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required string View { get; set; }
        public required string CreateUserName { get; set; }
        public List<string>? Tags { get; set; }
        public required DateTime CreateDate { get; set; }
    }

    public class PostDetailDto : PostDto
    {
        public List<ChangeRecords>? ChangeRecords { get; set; }
    }

    public class ChangeRecords
    {
        public DateOnly CreateDate { get; set; }
        public required string ChangeRecord { get; set; }
    }

    public class PostRequestDto : PageQueryDto
    {
        public List<int> TagIds { get; set; } = [];
        public string? Title { get; set; }
    }

    public class CreatePostDto
    {
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required int CreateUserId { get; set; }
        public List<string>? Tags { get; set; }
    }

    public class UpdatePostDto : CreatePostDto
    {
        public required int Id { get; set; }
    }
}
