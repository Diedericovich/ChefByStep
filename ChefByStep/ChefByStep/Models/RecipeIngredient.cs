using System;
using System.Collections.Generic;
using System.Text;

namespace ChefByStep.Models
{
    public class RecipeIngredient : BaseModel
    {
        public int IngredientId { get; set; }
        public int RecipeId { get; set; }
        public string Amount { get; set; }
        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
