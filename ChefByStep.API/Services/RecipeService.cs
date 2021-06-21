using AutoMapper;
using ChefByStep.API.Entities;
using ChefByStep.API.Entities.DTOs;
using ChefByStep.API.Repos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.API.Services
{
    public class RecipeService : IRecipeService
    {
        private IRecipeRepo _recipeRepo;
        private IMapper _mapper;

        public RecipeService(IRecipeRepo recipeRepo, IMapper mapper)
        {
            _recipeRepo = recipeRepo;
            _mapper = mapper;
        }

        public async Task AddRecipeAsync(Recipe recipe)
        {
            await _recipeRepo.AddAsync(recipe);
        }

        public async Task DeleteRecipeAsync(int id)
        {
            await _recipeRepo.DeleteAsync(id);
        }

        public async Task<RecipeDto> GetRecipeAsync(int id)
        {
            Recipe recipe = await _recipeRepo.GetAsync(id);
            RecipeDto result = _mapper.Map<RecipeDto>(recipe);
            return result;
        }

        public async Task<List<Recipe>> GetAllRecipesAsync()
        {
            List<Recipe> recipeList = await _recipeRepo.GetAllAsync();

            return recipeList;
        }

        public async Task UpdateRecipeAsync(Recipe recipe)
        {
            await _recipeRepo.UpdateAsync(recipe);
        }
    }
}