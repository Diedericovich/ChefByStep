namespace ChefByStep.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Models;
    using Services.Repositories;
    using Views;
    using Xamarin.Forms;

    public class AboutViewModel : BaseViewModel
    {
        private MockRecipeRepo _repo;
        private ObservableCollection<Recipe> _recipes;

        public ObservableCollection<Recipe> Recipes
        {
            get { return _recipes; }

            set
            {
                _recipes = value;
                OnPropertyChanged(nameof(Recipes));
            }
        }

        public Command<Recipe> ItemTapped { get; }

        public AboutViewModel()
        {
            _repo = new MockRecipeRepo();

            ItemTapped = new Command<Recipe>(OnRecipeSelected);
        }

        private async Task<ObservableCollection<Recipe>> ShowAllTheRecipes()
        {
            IList<Recipe> allRecipes = await _repo.GetAllRecipes();
            Recipes = (ObservableCollection<Recipe>) allRecipes;
            return (ObservableCollection<Recipe>) allRecipes;
        }

        private async void OnRecipeSelected(Recipe recipe)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?{nameof(DetailPageViewModel.RecipeId)}={recipe.Id}");
        }
    }
}