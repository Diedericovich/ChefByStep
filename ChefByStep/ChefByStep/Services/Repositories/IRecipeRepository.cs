namespace ChefByStep.Services.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ChefByStep.Models;

    public interface IRecipeRepository
    {
        Task<Recipe> GetRecipe(int id);

        Task<List<Recipe>> GetAllRecipes();
    }
}