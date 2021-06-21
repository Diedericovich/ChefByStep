using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.ASP.Models
{
    public class ApplicationUser : BaseModel
    {
        public Account Account { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        public List<Recipe> CreatedRecipes { get; set; }

        public List<Recipe> FavouriteRecipes { get; set; }

        public List<Recipe> CompletedRecipes { get; set; }

        public List<RecipeRating> Ratings { get; set; }
    }
}