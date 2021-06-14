using ChefByStep.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.API.Services
{
    public interface IRecipeService
    {
        Task AddRecipeAsync(Recipe recipe);
        Task DeleteRecipeAsync(int id);
        Task<List<Recipe>> GetAllRecipesAsync();
        Task<Recipe> GetRecipeAsync(int id);
        Task UpdateRecipeAsync(Recipe recipe);
    }
}