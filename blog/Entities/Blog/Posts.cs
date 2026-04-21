using blog.Entities.User;
using System.ComponentModel.DataAnnotations;

namespace blog.Entities.Blog
{
    public class Posts
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int View { get; set; } 
        public DateTime CreateDate { get; set; }
        public required int CreateUserId { get; set; }
        public Users User { get; set; }
        public ICollection<PostsChangeRecord> PostsChangeRecords { get; set; }
    }
}
