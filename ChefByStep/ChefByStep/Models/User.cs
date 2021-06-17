using System;
using System.Collections.Generic;
using System.Text;

namespace ChefByStep.Models
{
    public class User: BaseModel
    {
        public string Name { get; set; }
        //public string LastName { get; set; }
        public int AcoountId { get; set; }
        public int RoleIdn { get; set; }
        public List<Recipe> CreateRecipe { get; set; }
        public List<Recipe> FavoriteRecipes { get; set; }
        public List<Recipe> Completedrecipe { get; set; }
        public List<RecipeRating> Ratings { get; set; }

    }
}
