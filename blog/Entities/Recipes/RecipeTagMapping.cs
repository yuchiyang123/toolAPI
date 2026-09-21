using System.ComponentModel.DataAnnotations.Schema;

namespace blog.Entities.Recipes
{
    [Table("RecipeTagMapping")]
    public class RecipeTagMapping
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int RecipeTagId { get; set; }
        public Recipe Recipe { get; set; } = null!;
        public RecipeTag RecipeTag { get; set; } = null!;
    }
}
