using System.ComponentModel.DataAnnotations.Schema;

namespace blog.Entities.Recipes
{
    [Table("RecipeStepMapping")]
    public class RecipeStepMapping
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public int RecipeStepId { get; set; }
        public RecipeStep RecipeStep { get; set; }
        public Recipe Recipe { get; set; }
    }
}
