namespace ChefByStep.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    using ChefByStep.Models;
    using ChefByStep.Services.Repositories;
    using ChefByStep.Views;

    using Xamarin.Forms;

    internal class UserFavouriteRecipesViewModel : BaseViewModel
    {
        private RecipeRepository _repo;

        public UserFavouriteRecipesViewModel()
        {
            _repo = new RecipeRepository();
            ItemTapped = new Command<Recipe>(OnRecipeSelected);
        }

        public Command<Recipe> ItemTapped { get; }

        private async void OnRecipeSelected(Recipe recipe)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?{nameof(DetailPageViewModel.RecipeId)}={recipe.Id}");
        }
    }
}