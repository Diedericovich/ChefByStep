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
        }

        private async Task LoadRecipe(int id)
        {
            try
            {
                var recipe = await _repo.GetRecipe(id);
                SelectedRecipe = recipe;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to load place");
            }
        }

    }
}