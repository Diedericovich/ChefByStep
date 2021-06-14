using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.ASP.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }

        public Account Account { get; set; }

        public string Name { get; set; }

        public List<Recipe> CreatedRecipes { get; set; }

        public List<Recipe> FavouriteRecipes { get; set; }

        public List<Recipe> CompletedRecipes { get; set; }

        public List<RecipeRating> Ratings { get; set; }
    }
}