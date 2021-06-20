using System.Collections.Generic;

namespace ChefByStep.API.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RecipeIngredient> Recipes { get; set; }
    }
}