namespace ChefByStep.ASP.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ChefByStep.ASP.Models;

    public interface IRecipeRatingRepo
    {
        Task<RecipeRating> GetRecipeRatingAsync(int id);

        Task<IList<RecipeRating>> GetRecipeRatingsAsync();

        Task PostRecipeRatingAsync(RecipeRating recipeRating);
    }
}