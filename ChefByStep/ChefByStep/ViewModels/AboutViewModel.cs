using ChefByStep.Models;
using ChefByStep.Services.Repositories;
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

        //private async void OnRecipeSelected(Recipe recipe)
        //{
        //    Shell.Current.GoToAsync(
        //        $"{nameof(DetailPage)}?{nameof(DetailPageViewModel.PlaceId)}={place.ID}");
        //}

    }
}