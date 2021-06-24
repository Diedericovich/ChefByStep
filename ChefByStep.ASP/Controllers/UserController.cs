using ChefByStep.ASP.Services;
using ChefByStep.ASP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.ASP.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        public async Task<IActionResult> IndexAsync()
        {
            string name = User.Identity.Name;
            var user = await _service.GetUserByNameAsync(name);
            var viewModel = new UserViewModel
            {
                User = user
            };

            return View(viewModel);
        }
    }
}