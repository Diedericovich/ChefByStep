using ChefByStep.API.Entities;
using ChefByStep.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.API.Controllers
{
    [ApiController, Route("api/[controller]")]

    public class IngredientController : ControllerBase
    {
        private IIngredientService _service;

        public IngredientController(IIngredientService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task AddIngredientAsync(Ingredient ingredient)
        {
            await _service.AddIngredientAsync(ingredient);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteIngredientAsync(int id)
        {
            try
            {
                await _service.DeleteIngredientAsync(id);
                return Ok("Delete Ok");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<Ingredient> GetIngredientAsync(int id)
        {
            return await _service.GetIngredientAsync(id);
        }

        [HttpGet]
        public async Task<IEnumerable<Ingredient>> GetAllIngredientsAsync()
        {
            return await _service.GetAllIngredientsAsync();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateIngredientAsync(Ingredient ingredient)
        {
            try
            {
                await _service.UpdateIngredientAsync(ingredient);
                return Ok("Update OK");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}