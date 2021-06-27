using ChefByStep.Models;
using ChefByStep.Services.Repositories;
using ChefByStep.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChefByStep.ViewModels
{
    [QueryProperty(nameof(CategoryId), nameof(CategoryId))]
    internal class RecipeCategoryViewModel : BaseViewModel
    {
        private RecipeRepository _repo;
        private int categoryId;
        public Command<Recipe> ItemTapped { get; }

        private async void OnRecipeSelected(Recipe recipe)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?{nameof(DetailPageViewModel.RecipeId)}={recipe.Id}");
        }

        public int CategoryId
        {
            get { return categoryId; }
            set
            {
                categoryId = value;
                LoadRecipes(value);
            }
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

        private string categoryName;

        public string CategoryName
        {
            get { return categoryName; }
            set
            {
                categoryName = value;
                OnPropertyChanged(nameof(CategoryName));
            }
        }

        public RecipeCategoryViewModel()
        {
            _repo = new RecipeRepository();
            ItemTapped = new Command<Recipe>(OnRecipeSelected);
        }

        private async Task LoadRecipes(int id)
        {
            try
            {
                var recipes = await _repo.GetAllRecipesByCategory(id);
                Recipes = new ObservableCollection<Recipe>(recipes);
                switch (id)
                {
                    case 1:
                        CategoryName = "Breakfast";
                        break;

                    case 2:
                        CategoryName = "Lunch";
                        break;

                    case 3:
                        CategoryName = "Dinner";
                        break;

                    case 4:
                        CategoryName = "Dessert";
                        break;

                    default:
                        categoryName = "";
                        break;
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to load recipes");
            }
        }
    }
}