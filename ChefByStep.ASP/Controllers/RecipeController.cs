namespace ChefByStep.ASP.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoMapper;

    using ChefByStep.ASP.Models;
    using ChefByStep.ASP.Services;
    using ChefByStep.ASP.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class RecipeController : Controller
    {
        private readonly IRecipeService _recipeService;
        private readonly IUserService _userService;
        private readonly IRecipeRatingService _ratingService;

        private readonly IMapper _mapper;

        public RecipeController(IRecipeService recipeService, IMapper mapper, IRecipeRatingService ratingService, IUserService userService)
        {
            _recipeService = recipeService;
            _ratingService = ratingService;
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        public async Task<ActionResult> IndexAsync()
        {
            ICollection<Recipe> recipes = await _recipeService.GetRecipesAsync();
            var viewModel = new RecipeViewModel { Recipes = _mapper.Map<ICollection<Recipe>>(recipes) };
            return View(viewModel);
        }

        public async Task<ActionResult> DetailAsync(int id)
        {
            Recipe recipe = await _recipeService.GetRecipeAsync(id);
            RecipeDetailRatingViewModel viewModel = new RecipeDetailRatingViewModel();
            viewModel.RecipeDetailVm = _mapper.Map<RecipeDetailViewModel>(recipe);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DetailAsync(RecipeDetailRatingViewModel vm)
        {
            var recipeRating = this._mapper.Map<RecipeRating>(vm.RecipeRatingVm);

            string name = User.Identity.Name;
            var user = await _userService.GetUserByNameAsync(name);
            recipeRating.UserId = user.Id;
            _ratingService.PostRecipeRating(recipeRating);

            var temp = vm.RecipeRatingVm.RecipeId;

            return RedirectToAction($"Detail", temp);
        }

        public async Task<ActionResult> StepsAsync(int id)
        {
            Recipe recipe = await _recipeService.GetRecipeAsync(id);
            RecipeDetailViewModel viewModel = _mapper.Map<RecipeDetailViewModel>(recipe);

            return View(viewModel);
        }

        // GET: RecipeController/Create
        //[Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecipeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RecipeCreateViewModel vm)
        {
            bool IsValid = TryValidateModel(vm);
            if (IsValid)
            {
                string name = User.Identity.Name;
                var user = await _userService.GetUserByNameAsync(name);
                Recipe recipe = _mapper.Map<Recipe>(vm);
                recipe.CreatedById = user.Id;
                await _recipeService.PostRecipe(recipe);
                return RedirectToAction("Index");
            }
            return View(vm);
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