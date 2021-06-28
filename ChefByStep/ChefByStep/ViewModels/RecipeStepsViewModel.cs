namespace ChefByStep.ViewModels
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using ChefByStep.Models;
    using ChefByStep.Services.Repositories;

    using Xamarin.Forms;

    [QueryProperty(nameof(RecipeId), nameof(RecipeId))]
    public class RecipeStepsViewModel : BaseViewModel
    {
        private Recipe selectedRecipe;

        public Recipe SelectedRecipe
        {
            get
            {
                return selectedRecipe;
            }
            set
            {
                selectedRecipe = value;
                OnPropertyChanged(nameof(SelectedRecipe));
            }
        }

        private int recipeId;

        public int RecipeId
        {
            get
            {
                return recipeId;
            }
            set
            {
                recipeId = value;
                LoadRecipe(value);
            }
        }

        private RecipeRepository _repo;

        public RecipeStepsViewModel()
        {
            _repo = new RecipeRepository();
            //CookingTime = ConvertCookingTime(SelectedRecipe.CookTimeInMin);
        }

        private async Task LoadRecipe(int id)
        {
            try
            {
                var recipe = await _repo.GetRecipe(id);
                int counter = 1;
                foreach (var step in recipe.Steps)
                {
                    step.Id = counter;
                    counter++;
                }
                recipe.CookingTime = ConvertCookingTime(recipe.CookTimeInMin);
                SelectedRecipe = recipe;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to load Recipes");
            }
        }

        private string ConvertCookingTime(int time)
        {
            TimeSpan result = TimeSpan.FromMinutes(time);
            string fromTimeString = result.ToString("hh':'mm");
            return fromTimeString;
        }
    }
}