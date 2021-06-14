using ChefByStep.Models;
using ChefByStep.Services.Repositories;
using ChefByStep.Views;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ChefByStep.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private MockRecepieRepo _repo;

        public AboutViewModel()
        {
            _repo = new MockRecepieRepo();
            ShowAllTheRecipes();
            ItemTapped = new Command<Recipe>(OnRecipeSelected);
        }
        
       

        private ObservableCollection<Recipe> recipes;

        public ObservableCollection<Recipe> Recipes
        {
            get { return recipes; }
            set { 
                recipes = value;
                OnPropertyChanged(nameof(Recipes));
            }
        }


        public Command<Recipe> ItemTapped { get; }

        //private IMockRecipeRepo _repo;
        //public AboutViewModel(IMockRecipeRepo repo)
        //{
        //    _repo = repo;
        //    ShowAllTheRecipes();
        //    //ItemTapped = new Command<Recipe>(OnPlaceSelected);

        //}


        private void ShowAllTheRecipes()
        {
            var recipes = _repo.GetAllRecipes();
            Recipes = new ObservableCollection<Recipe>(recipes);
        }

        private async void OnRecipeSelected(Recipe recipe)
        {
            await Shell.Current.GoToAsync(
                $"{nameof(DetailPage)}?{nameof(DetailPageViewModel.RecipeId)}={recipe.Id}");
        }

    }
}