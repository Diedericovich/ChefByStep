using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefByStep.API.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<RecipeRating> Ratings { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }
        public int CreatedById { get; set; }

        [InverseProperty("CreatedRecipe")]
        public User CreatedBy { get; set; }

        [InverseProperty("FavoriteRecipes")]
        public List<User> FavouritedBy { get; set; }

        [InverseProperty("CompletedRecipes")]
        public List<User> CompletedBy { get; set; }
    }
}