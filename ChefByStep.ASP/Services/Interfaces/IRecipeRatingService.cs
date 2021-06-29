namespace ChefByStep.ASP.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ChefByStep.ASP.Models;

    public interface IRecipeRatingService
    {
        Task<IList<RecipeRating>> GetRecipeRatingsAsync();

        Task<RecipeRating> GetRecipeRatingAsync(int id);

        Task PostRecipeRating(RecipeRating recipeRating);
    }
}