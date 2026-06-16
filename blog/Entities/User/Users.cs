using System.ComponentModel.DataAnnotations.Schema;
using blog.Entities.Blog;
using blog.Entities.Judge;

namespace blog.Entities.User
{
    [Table("Users")]
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime LogInDate { get; set; }
        public DateTime CreateDate { get; set; }
        public ICollection<Posts> Posts { get; set; }
        public ICollection<PostsChangeRecord> PostsChangeRecords { get; set; }
        public ICollection<Submission> Submissions { get; set; }
    }
}
