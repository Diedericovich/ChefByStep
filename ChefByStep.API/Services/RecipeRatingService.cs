using ChefByStep.API.Entities;
using ChefByStep.API.Repos.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.API.Services
{
    public class RecipeRatingService : IRecipeRatingService
    {
        private IRecipeRatingRepo _repo;

        public RecipeRatingService(IRecipeRatingRepo repo)
        {
            _repo = repo;
        }

        public async Task AddRecipeRatingAsync(RecipeRating recipeRating)
        {
            await _repo.AddAsync(recipeRating);
        }

        public async Task DeleteRecipeRatingAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
        public async Task<RecipeRating> GetRecipeRatingAsync(int id)
        {
            return await _repo.GetAsync(id);
        }
        public async Task<List<RecipeRating>> GetAllRecipeRatingsAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task UpdateRecipeRatingAsync(RecipeRating recipeRating)
        {
            await _repo.UpdateAsync(recipeRating);
        }

    }
}
