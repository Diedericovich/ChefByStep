using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefByStep.API.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(35), MinLength(2)]
        public string Name { get; set; }

        public List<RecipeIngredient> Recipes { get; set; }
    }
}