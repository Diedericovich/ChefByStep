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
            string name = User.Identity.Name;
            var user = await _userService.GetUserByNameAsync(name);
            viewModel.RecipeRatingVm = new RecipeRatingViewModel { UserId = user.Id, User = user };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DetailAsync(RecipeDetailRatingViewModel vm)
        {
            var recipeRating = this._mapper.Map<RecipeRating>(vm.RecipeRatingVm);
            await _ratingService.PostRecipeRating(recipeRating);

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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> EditAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Recipe recipe = await _recipeService.GetRecipeAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            RecipeEditViewModel vm = _mapper.Map<RecipeEditViewModel>(recipe);
            return View(vm);
        }

        // POST: RecipeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(RecipeEditViewModel viewModel)
        {
            bool isValid = TryValidateModel(viewModel);

            if (!isValid)
            {
                return View(viewModel);
            }

            Recipe recipe = _mapper.Map<Recipe>(viewModel);
            await _recipeService.UpdateRecipe(recipe);
            return RedirectToAction("Index");
        }

        // GET: RecipeController/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            Recipe recipe = await _recipeService.GetRecipeAsync(id);
            RecipeDeleteViewModel vm = _mapper.Map<RecipeDeleteViewModel>(recipe);
            return View(vm);
        }

        // POST: RecipeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, IFormCollection collection)
        {
            try
            {
                await _recipeService.DeleteRecipeAsync(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}