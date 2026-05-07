using System.ComponentModel.DataAnnotations.Schema;

namespace blog.Entities.Recipes
{
    [Table("RecipeTag")]
    public class RecipeTag
    {
        public int Id { get; set; }
        public required string Tag { get; set; }
        public ICollection<RecipeTagMapping> RecipeTagMappings { get; set; }
    }
}
