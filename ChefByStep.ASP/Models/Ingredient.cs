using System.Collections.Generic;

namespace ChefByStep.ASP.Models
{
    public class Ingredient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Quantity { get; set; }

        public List<Recipe> Recipes { get; set; }
    }
}