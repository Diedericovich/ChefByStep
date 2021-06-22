namespace ChefByStep.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    using ChefByStep.Models;
    using ChefByStep.Services.Repositories;
    using ChefByStep.Views;

    using Xamarin.Forms;

    class UserFavouriteRecipesViewModel : BaseViewModel
    {
        private RecipeRepository _repo;

        public UserFavouriteRecipesViewModel()
        {
            _repo = new RecipeRepository();
            ShowUserFavouriteRecipes();
            ItemTapped = new Command<Recipe>(OnRecipeSelected);
        }

        private ObservableCollection<Recipe> recipes;

        public ObservableCollection<Recipe> Recipes
        {
            get
            {
                return recipes;
            }

            set
            {
                recipes = value;
                OnPropertyChanged(nameof(Recipes));
            }
        }

        public Command<Recipe> ItemTapped { get; }

        private async Task ShowUserFavouriteRecipes()
        {
            var recipes = ActiveUser.ApplicationUser.FavoriteRecipes;
            Recipes = new ObservableCollection<Recipe>(recipes);
        }

        private async void OnRecipeSelected(Recipe recipe)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?{nameof(DetailPageViewModel.RecipeId)}={recipe.Id}");
        }
    }
}