using System.Collections.Generic;

namespace ChefByStep.API.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public List<Recipe> Recipes { get; set; }
    }
}