namespace ChefByStep.ASP.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ChefByStep.ASP.Data;
    using ChefByStep.ASP.Models;

    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepo _repo;

        public RecipeService(IRecipeRepo repo)
        {
            this._repo = repo;
        }

        public async Task<IList<Recipe>> GetRecipesAsync()
        {
            IList<Recipe> recipes = await _repo.GetRecipesAsync();
            return recipes;
        }

        public async Task<Recipe> GetRecipeAsync(int id)
        {
            var recipe = await this._repo.GetRecipeAsync(id);
            return recipe;
        }
    }
}
