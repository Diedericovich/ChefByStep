using ChefByStep.API.Entities;
using ChefByStep.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.API.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class RecipeController: ControllerBase
    {
        private IRecipeService _service;

        public RecipeController(IRecipeService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task AddRecipeAsync(Recipe recipe)
        {
            await _service.AddRecipeAsync(recipe);
        }

        [HttpDelete("{id})")]
        public async Task<ActionResult> DeleteRecipeAsync(int id)
        {
            await _service.DeleteRecipeAsync(id);
            return Ok("Delete Ok");
        }

        [HttpGet("{id}")]
        public async Task<Recipe> GetRecipeAsync(int id)
        {
            return await _service.GetRecipeAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            return await _service.GetAllRecipesAsync();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateRecipeAsync(Recipe recipe)
        {
             await _service.UpdateRecipeAsync(recipe);
            return Ok("Update OK");
        }

    }
}
