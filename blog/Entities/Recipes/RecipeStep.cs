using System.ComponentModel.DataAnnotations.Schema;

namespace blog.Entities.Recipes
{
    [Table("RecipeStep")]
    public class RecipeStep
    {
        public int Id { get; set; }
        public int Step { get; set; }
        public required string Description { get; set; }
        public string? Image { get; set; }
        public ICollection<RecipeStepMapping> RecipeStepMappings { get; set; }
    }
}
