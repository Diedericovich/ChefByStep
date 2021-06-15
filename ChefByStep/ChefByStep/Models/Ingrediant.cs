using System;
using System.Collections.Generic;
using System.Text;

namespace ChefByStep.Models
{
    public class Ingrediant:BaseModel
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public List<Recipe> Recipes { get; set; }
    }
}
