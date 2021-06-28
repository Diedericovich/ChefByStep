using ChefByStep.API.Entities;
using ChefByStep.API.Entities.DTOs;
using ChefByStep.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.API.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class RecipeController : ControllerBase
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRecipeAsync(int id)
        {
            try
            {
                await _service.DeleteRecipeAsync(id);
                return Ok("Delete Ok");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<RecipeDto> GetRecipeAsync(int id)
        {
            return await _service.GetRecipeAsync(id);
        }

        [HttpGet("Search/{searchText}")]
        public async Task<IEnumerable<Recipe>> GetRecipeBySearchAsync(string searchText)
        {
            return await _service.GetAllBySearch(searchText);
        }

        [HttpGet]
        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            return await _service.GetAllRecipesAsync();
        }

        [HttpGet("ByCategory/{categoryId}")]
        public async Task<IEnumerable<Recipe>> GetAllByCategory(int categoryId)
        {
            return await _service.GetAllByCategory(categoryId);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateRecipeAsync(Recipe recipe)
        {
            try
            {
                await _service.UpdateRecipeAsync(recipe);
                return Ok("Update OK");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}