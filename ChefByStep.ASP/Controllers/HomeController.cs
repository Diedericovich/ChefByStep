using AutoMapper;
using ChefByStep.ASP.Models;
using ChefByStep.ASP.Services;
using ChefByStep.ASP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRecipeService _service;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IRecipeService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexAsync()
        {
            ICollection<Recipe> recipes = await _service.GetRecipesAsync();
            var viewModel = new RecipeViewModel
            {
                Recipes = _mapper.Map<ICollection<Recipe>>(recipes)
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
