using AutoMapper;
using ChefByStep.ASP.Models;
using ChefByStep.ASP.Services;
using ChefByStep.ASP.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.ASP
{
    public class RecipeController : Controller
    {
        private readonly IRecipeService _service;
        private readonly IMapper _mapper;

        public RecipeController(IRecipeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            ICollection<Recipe> recipes = await _service.GetRecipesAsync();
            return View();
        }

        // GET: RecipeController/Details/5
        public async Task<ActionResult> DetailAsync(int id)
        {
            Recipe recipe = await _service.GetRecipeAsync(id);
            RecipeDetailViewModel viewModel = _mapper.Map<RecipeDetailViewModel>(recipe);

            return View(viewModel);
        }

        // GET: RecipeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecipeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RecipeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RecipeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RecipeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RecipeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
