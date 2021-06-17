namespace ChefByStep.Models
{
    using System.Collections.Generic;

    public class User : BaseModel
    {
        public string FirstName { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public int AcountId { get; set; }

        public int RoleIdn { get; set; }

        public List<Recipe> CreateRecipe { get; set; }

        public List<Recipe> FavoriteRecipes { get; set; }

        public List<Recipe> Completedrecipe { get; set; }

        public List<RecipeRating> Ratings { get; set; }
    }
}