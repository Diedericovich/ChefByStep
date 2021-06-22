namespace ChefByStep.ASP.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ChefByStep.ASP.Models;

    public interface IRecipeService
    {
        Task<Recipe> GetRecipeAsync(int id);

        Task<IList<Recipe>> GetRecipesAsync();
    }
}