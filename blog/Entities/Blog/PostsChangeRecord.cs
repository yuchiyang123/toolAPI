using System.ComponentModel.DataAnnotations.Schema;
using blog.Entities.User;

namespace blog.Entities.Blog
{
    [Table("PostsChangeRecord")]
    public class PostsChangeRecord
    {
        public int Id { get; set; }
        public int FK_PostsId { get; set; }
        public required string ChangeRecord { get; set; }
        public DateOnly CreateDate { get; set; }
        public int CreateUserId { get; set; }
        public Users Users { get; set; }
        public Posts Posts { get; set; }
    }
}
