using ChefByStep.ASP.Data;
using ChefByStep.ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.ASP.Services
{
    public class RecipeService : IRecipeService
    {
        private IRecipeRepo _repo;

        public RecipeService(IRecipeRepo repo)
        {
            _repo = repo;
        }

        public async Task<IList<Recipe>> GetRecipesAsync()
        {
            IList<Recipe> recipes = await _repo.GetRecipesAsync();
            return recipes;
        }

        public async Task<Recipe> GetRecipeAsync(int id)
        {
            var recipe = await _repo.GetRecipeAsync(id);
            return recipe;
        }

        public async Task PostRecipe(Recipe recipe)
        {
            await _repo.PostRecipeAsync(recipe);
        }

        public async Task UpdateRecipe(Recipe recipe)
        {
            await _repo.UpdateRecipeAsync(recipe);
        }

        public async Task DeleteRecipeAsync(int id)
        {
            await _repo.DeleteRecipe(id);
        }
    }
}