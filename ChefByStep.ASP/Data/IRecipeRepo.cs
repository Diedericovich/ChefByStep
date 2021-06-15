using ChefByStep.ASP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.ASP.Data
{
    public interface IRecipeRepo
    {
        Task<Recipe> GetRecipeAsync(int id);
        Task<IList<Recipe>> GetRecipesAsync();
    }
}