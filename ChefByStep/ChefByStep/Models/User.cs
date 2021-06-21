namespace ChefByStep.Models
{
    using System.Collections.Generic;

    public class User : BaseModel
    {
        public int AccountId { get; set; }

        public int RoleId { get; set; }

        public string Name { get; set; }

        public List<Recipe> CreatedRecipe { get; set; }

        public List<Recipe> FavoriteRecipes { get; set; }

        public List<Recipe> CompletedRecipes { get; set; }

        public List<RecipeRating> Rating { get; set; }
    }
}