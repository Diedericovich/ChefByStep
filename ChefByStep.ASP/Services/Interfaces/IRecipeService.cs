using ChefByStep.ASP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.ASP.Services
{
    public interface IRecipeService
    {
        Task DeleteRecipeAsync(int id);
        Task<Recipe> GetRecipeAsync(int id);
        Task<IList<Recipe>> GetRecipesAsync();
        Task PostRecipe(Recipe recipe);
        Task UpdateRecipe(Recipe recipe);
    }
}