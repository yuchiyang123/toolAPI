using System.ComponentModel.DataAnnotations.Schema;

namespace blog.Entities.Recipes
{
    [Table("RecipeDetailMapping")]
    public class RecipeDetailMapping
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int RecipeDetailId { get; set; }
        public Recipe Recipe { get; set; }
        public RecipeDetail RecipeDetail { get; set; }
    }
}
