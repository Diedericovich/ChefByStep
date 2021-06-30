namespace ChefByStep.ViewModels
{
    using ChefByStep.Models;
    using ChefByStep.Services.Repositories;
    using ChefByStep.Views;
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    [QueryProperty(nameof(RecipeId), nameof(RecipeId))]
    public class DetailPageViewModel : BaseViewModel
    {
        private RecipeRepository _repo;
        private UserRepository _userRepo;

        public DetailPageViewModel()
        {
            _repo = new RecipeRepository();
            _userRepo = new UserRepository();
            SelectedRecipe = new Recipe();
            OnButtonClickedCommand = new Command(GoToStepsPage);
            OnButtonUserRecipeFavourite = new Command(AddRecipeToUserFavourites);
        }

        private async void AddRecipeToUserFavourites()
        {
            if (!ActiveUser.ApplicationUser.FavoriteRecipes.Contains(selectedRecipe))
            {
                this.ActiveUser.ApplicationUser.FavoriteRecipes.Add(SelectedRecipe);
                SelectedRecipe.IsFavorited = true;
                FavoriteButton = "heartfull.png";
                var favourite = new FavouriteDto
                {
                    UserId = ActiveUser.ApplicationUser.Id,
                    RecipeId = SelectedRecipe.Id
                };
                await _userRepo.AddFavouriteRecipe(favourite);
            }
        }

        public async void GoToStepsPage()
        {
            var recipe = SelectedRecipe;

            await Shell.Current.GoToAsync(
                $"{nameof(RecipeStepsPage)}?{nameof(RecipeStepsViewModel.RecipeId)}={SelectedRecipe.Id}");
        }

        public ICommand OnButtonClickedCommand { get; }
        public ICommand OnButtonUserRecipeFavourite { get; }

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

        private string favoriteButton;

        public string FavoriteButton
        {
            get { return favoriteButton; }
            set
            {
                favoriteButton = value;
                OnPropertyChanged(nameof(FavoriteButton));
            }
        }

        private async Task LoadRecipe(int id)
        {
            try
            {
                var recipe = await _repo.GetRecipe(id);
                recipe.AverageRating = CalculateAverageRating(recipe);
                if (ActiveUser.ApplicationUser.FavoriteRecipes.FirstOrDefault(x => x.Title == recipe.Title) != null)
                {
                    recipe.IsFavorited = true;
                    FavoriteButton = "heartfull.png";
                }
                else
                {
                    FavoriteButton = "heartblack.png";
                }
                SelectedRecipe = recipe;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to load recipes");
            }
        }

        private static int CalculateAverageRating(Recipe recipe)
        {
            int averageRating = 0;
            if (recipe.Ratings.Count == 0)
            {
                return 3;
            }
            else
            {
                foreach (var rating in recipe.Ratings)
                {
                    averageRating += Convert.ToInt32(rating.Rating);
                }
                int result = averageRating / recipe.Ratings.Count;
                return result;
            }
        }
    }
}