using ChefByStep.ASP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.ASP.Services
{
    public interface IRecipeService
    {
        Task<Recipe> GetRecipeAsync(int id);
        Task<IList<Recipe>> GetRecipesAsync();
    }
}