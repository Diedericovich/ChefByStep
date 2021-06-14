using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.API.Entities
{
    public class User
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        public int RoleId { get; set; }

        public string Name { get; set; }

        public List<Recipe> CreatedRecipe { get; set; }

        public List<Recipe> FavoriteRecipes { get; set; }

        public List<Recipe> CompletedRecipes { get; set; }

        public List<RecipeRating> Rating { get; set; }





    }
}
