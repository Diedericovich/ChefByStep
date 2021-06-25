namespace ChefByStep.ASP.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ChefByStep.ASP.Data;
    using ChefByStep.ASP.Models;

    public class RecipeRatingService : IRecipeRatingService
    {
        private IRecipeRatingRepo _repo;

        public RecipeRatingService(IRecipeRatingRepo repo)
        {
            _repo = repo;
        }

        public async Task<IList<RecipeRating>> GetRecipeRatingsAsync()
        {
            IList<RecipeRating> recipes = await _repo.GetRecipeRatingsAsync();
            return recipes;
        }

        public async Task<RecipeRating> GetRecipeRatingAsync(int id)
        {
            var recipeRating = await _repo.GetRecipeRatingAsync(id);
            return recipeRating;
        }

        public async Task PostRecipeRating(RecipeRating recipeRating)
        {
            await _repo.PostRecipeRatingAsync(recipeRating);
        }
    }
}