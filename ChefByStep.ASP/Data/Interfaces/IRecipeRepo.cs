using ChefByStep.ASP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.ASP.Data
{
    public interface IRecipeRepo
    {
        Task DeleteRecipe(int id);
        Task<Recipe> GetRecipeAsync(int id);
        Task<IList<Recipe>> GetRecipesAsync();
        Task AddRecipeAsync(Recipe recipe);
        Task UpdateRecipeAsync(Recipe recipe);
    }
}