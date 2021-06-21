using System.Collections.Generic;

namespace ChefByStep.ASP.Models
{
    public class Ingredient : BaseModel
    {
        public string Name { get; set; }

        public double Quantity { get; set; }

        public List<RecipeIngredient> Recipes { get; set; }
    }
}