namespace ChefByStep.Models
{
    using System.Collections.Generic;

    public class Ingredient : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Quantity { get; set; }

        public List<RecipeIngredient> Recipes { get; set; }
    }
}