using ChefByStep.API.Entities;
using ChefByStep.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.API.Controllers
{
    [ApiController, Route("api/[controller]")]

    public class RecipeRatingController: ControllerBase
    {
        private IRecipeRatingService _service;

        public RecipeRatingController(IRecipeRatingService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task AddRecipeRatingAsync(RecipeRating recipeRating)
        {
            await _service.AddRecipeRatingAsync(recipeRating);
        }

        [HttpDelete("{id})")]
        public async Task<ActionResult> DeleteRecipeRatingAsync(int id)
        {
            await _service.DeleteRecipeRatingAsync(id);
            return Ok("Delete Ok");
        }

        [HttpGet("{id}")]
        public async Task<RecipeRating> GetRecipeRatingAsync(int id)
        {
            return await _service.GetRecipeRatingAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<RecipeRating>> GetAllRecipeRatingsAsync()
        {
            return await _service.GetAllRecipeRatingsAsync();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateRecipeRatingAsync(RecipeRating recipeRating)
        {
            await _service.UpdateRecipeRatingAsync(recipeRating);
            return Ok("Update OK");
        }

    }
}
