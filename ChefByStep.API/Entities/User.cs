using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefByStep.API.Entities
{
    public class User
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        public int RoleId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<Recipe> CreatedRecipes { get; set; }

        public List<Recipe> FavoriteRecipes { get; set; }

        public List<Recipe> CompletedRecipes { get; set; }

        public List<RecipeRating> Ratings { get; set; }
    }
}