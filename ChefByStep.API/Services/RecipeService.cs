using ChefByStep.API.Entities;
using ChefByStep.API.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.API.Services
{
    public class RecipeService : IRecipeService
    {
        private IRecipeRepo _recipeRepo;

        public RecipeService(IRecipeRepo recipeRepo)
        {
            _recipeRepo = recipeRepo;
        }

        public async Task AddRecipeAsync(Recipe recipe)
        {
            await _recipeRepo.AddAsync(recipe);
        }

        public async Task DeleteRecipeAsync(int id)
        {
            await _recipeRepo.DeleteAsync(id);
        }

        public async Task<List<Recipe>> GetAllRecipesAsync()
        {
            List<Recipe> recipeList = await _recipeRepo.GetAllAsync();

            return recipeList;
        }
        public async Task<Recipe> GetRecipeAsync(int id)
        {
            Recipe recipe = await _recipeRepo.GetAsync(id);
            return recipe;
        }
        public async Task UpdateRecipeAsync(Recipe recipe)
        {
            await _recipeRepo.UpdateAsync(recipe);
        }
    }
}