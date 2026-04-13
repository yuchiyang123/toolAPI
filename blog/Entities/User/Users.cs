using blog.Entities.Blog;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blog.Entities.User
{
    [Table("Users")]
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime LogInDate { get; set; }
        public DateTime CreateDate { get; set; }
        public ICollection<Posts> Posts { get; set; }
    }
}
