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
    public class UserController : ControllerBase
    {
        private IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task AddUserAsync(User user)
        {
            await _service.AddUserAsync(user);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUserAsync(int id)
        {
            try
            {
                await _service.DeleteUserAsync(id);
                return Ok("Delete OK");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<User> GetUserAsync(int id)
        {
            return await _service.GetUserAsync(id);
        }

        [HttpGet]
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _service.GetAllUsersAsync();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUserAsync(User user)
        {
            try
            {
                await _service.UpdateUserAsync(user);
                return Ok("Update OK");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}