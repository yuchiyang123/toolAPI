using System.ComponentModel.DataAnnotations.Schema;
using blog.Entities.Recipes;

namespace blog.Entities
{
    [Table("Files")]
    public class Files
    {
        public int Id { get; set; }
        public required string Path { get; set; }
        public required string FileName { get; set; }
        public DateTime CreateDate { get; set; }
        public RecipeFileMapping RecipeFileMapping { get; set; }
    }
}
