using System.ComponentModel.DataAnnotations.Schema;

namespace blog.Entities.Recipes
{
    [Table("RecipeFileMapping")]
    public class RecipeFileMapping
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int FileId { get; set; }
        public Recipe Recipe { get; set; }
        public Files Files { get; set; }
    }
}
