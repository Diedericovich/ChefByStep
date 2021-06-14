using ChefByStep.API.Entities;
using ChefByStep.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.API.Controllers
{
    [ApiController, Route("api/[controller]")]

    public class StepController: ControllerBase
    {
        private IStepService _service;

        public StepController(IStepService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task AddStepAsync(Step step)
        {
            await _service.AddStepAsync(step);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteStepAsync(int id)
        {
            try
            {
                await _service.DeleteStepAsync(id);
                return Ok("Delete OK");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<Step> GetStepAsync(int id)
        {
            return await _service.GetStepAsync(id);
        }

        [HttpGet]
        public async Task<List<Step>> GetAllStepsAsync()
        {
            return await _service.GetAllStepsAsync();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateStepAsync(Step step)
        {
            try
            {
                await _service.UpdateStepAsync(step);
                return Ok("Update OK");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
