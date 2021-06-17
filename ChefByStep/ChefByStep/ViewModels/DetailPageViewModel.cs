namespace ChefByStep.ViewModels
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using ChefByStep.Models;
    using ChefByStep.Services.Repositories;
    using ChefByStep.Views;

    using Xamarin.Forms;

    [QueryProperty(nameof(RecipeId), nameof(RecipeId))]
    public class DetailPageViewModel : BaseViewModel
    {
        private RecipeRepository _repo;

        public DetailPageViewModel()
        {
            _repo = new RecipeRepository();
            SelectedRecipe = new Recipe();
            OnButtonClickedCommand = new Command(GoToStepsPage);
        }

        public async void GoToStepsPage()
        {
            var recipe = SelectedRecipe;

            await Shell.Current.GoToAsync(
                $"{nameof(RecipeStepsPage)}?{nameof(RecipeStepsViewModel.RecipeId)}={SelectedRecipe.Id}");
        }

        public ICommand OnButtonClickedCommand { get; }

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