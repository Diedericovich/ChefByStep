namespace ChefByStep.ASP.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoMapper;

    using ChefByStep.ASP.Models;
    using ChefByStep.ASP.Services;
    using ChefByStep.ASP.ViewModels;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class RecipeController : Controller
    {
        private readonly IRecipeService _service;
        private readonly IMapper _mapper;

        public RecipeController(IRecipeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ActionResult> IndexAsync()
        {
            ICollection<Recipe> recipes = await _service.GetRecipesAsync();
            var viewModel = new RecipeViewModel
            {
                Recipes = _mapper.Map<ICollection<Recipe>>(recipes)
            };
            return View(viewModel);
        }

        //public async Task<ActionResult> IndexAsync(RecipeViewModel viewModel)
        //{
        //    ICollection<Recipe> recipes = await _service.GetRecipesAsync();
        //    var viewModel = new RecipeViewModel
        //    {
        //        Recipes = _mapper.Map<ICollection<Recipe>>(recipes)
        //    };
        //    return View(viewModel);
        //}

        // GET: RecipeController/Details/5
        public async Task<ActionResult> DetailAsync(int id)
        {
            Recipe recipe = await _service.GetRecipeAsync(id);
            RecipeDetailViewModel viewModel = _mapper.Map<RecipeDetailViewModel>(recipe);

            return View(viewModel);
        }

        public async Task<ActionResult> StepsAsync(int id)
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
                return RedirectToAction(nameof(IndexAsync));
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
                return RedirectToAction(nameof(IndexAsync));
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
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
    }
}