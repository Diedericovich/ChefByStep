namespace ChefByStep.Models
{
    using System.Collections.Generic;

    public class Ingredient : BaseModel
    {
        public string Name { get; set; }

        public double Quantity { get; set; }

        public List<Recipe> Recipes { get; set; }
    }
}
