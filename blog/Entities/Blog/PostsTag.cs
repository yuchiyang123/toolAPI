using System.ComponentModel.DataAnnotations.Schema;

namespace blog.Entities.Blog
{
    [Table("PostsTag")]
    public class PostsTag
    {
        public int Id { get; set; }
        public required string Tag { get; set; }
        public DateTime CreateDate { get; set; }
        public ICollection<PostsTagMapping> PostsTagMapping { get; set; }
    }
}
