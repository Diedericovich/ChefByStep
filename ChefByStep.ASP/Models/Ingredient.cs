using System.Collections.Generic;
using System.ComponentModel;

namespace ChefByStep.ASP.Models
{
    public class Ingredient : BaseModel
    {
        [DisplayName("Ingredient: ")]
        public string Name { get; set; }

        public double Quantity { get; set; }

        public List<RecipeIngredient> Recipes { get; set; }
    }
}