using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.ASP.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Account Account { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public List<Recipe> CreatedRecipes { get; set; }
        [NotMapped]
        public List<Recipe> FavouriteRecipes { get; set; }
        [NotMapped]
        public List<Recipe> CompletedRecipes { get; set; }
        [NotMapped]
        public List<RecipeRating> Ratings { get; set; }
    }
}