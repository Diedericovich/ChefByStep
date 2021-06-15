using ChefByStep.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.API.Services
{
    public interface IRecipeRatingService
    {
        Task AddRecipeRatingAsync(RecipeRating recipeRating);
        Task DeleteRecipeRatingAsync(int id);
        Task<List<RecipeRating>> GetAllRecipeRatingsAsync();
        Task<RecipeRating> GetRecipeRatingAsync(int id);
        Task UpdateRecipeRatingAsync(RecipeRating recipeRating);
    }
}