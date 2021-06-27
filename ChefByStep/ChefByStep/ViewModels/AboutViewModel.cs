namespace ChefByStep.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using ChefByStep.Models;
    using ChefByStep.Services.Repositories;
    using ChefByStep.Views;

    using Xamarin.Forms;

    public class AboutViewModel : BaseViewModel
    {
        private RecipeRepository _repo;
        public ICommand GoToProfile { get; }

        public AboutViewModel()
        {
            _repo = new RecipeRepository();
            GoToProfile = new Command(GoToProfilePage);
            ShowAllTheRecipes();
            ItemTapped = new Command<Recipe>(OnRecipeSelected);
            CategoryTapped = new Command<string>(OnCategorySelected);
        }

        private async void GoToProfilePage()
        {
            await Shell.Current.GoToAsync(nameof(ProfilePage));
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
        public Command<string> CategoryTapped { get; }

        private async Task ShowAllTheRecipes()
        {
            var recipes = await _repo.GetAllRecipes();
            foreach (var recipe in recipes)
            {
                if (ActiveUser.ApplicationUser.FavoriteRecipes.FirstOrDefault(x => x.Title == recipe.Title) != null)
                {
                    recipe.IsFavorited = true;
                }
            }
            Recipes = new ObservableCollection<Recipe>(recipes);
        }

        private async void OnRecipeSelected(Recipe recipe)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?{nameof(DetailPageViewModel.RecipeId)}={recipe.Id}");
        }

        private async void OnCategorySelected(string id)
        {
            int categoryId = Convert.ToInt32(id);
            await Shell.Current.GoToAsync($"{nameof(RecipeCategoryPage)}?{nameof(RecipeCategoryViewModel.CategoryId)}={categoryId}");
        }
    }
}