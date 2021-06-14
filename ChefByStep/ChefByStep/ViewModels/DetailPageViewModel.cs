using ChefByStep.Models;
using ChefByStep.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace ChefByStep.ViewModels
{
    [QueryProperty(nameof(RecipeId), nameof(RecipeId))]
    public class DetailPageViewModel:BaseViewModel
    {
        private MockRecepieRepo _repo;

        public DetailPageViewModel()
        {
            _repo = new MockRecepieRepo();
            SelectedRecipe = new Recipe();
        }


        private Recipe selectedRecipe;

        public Recipe SelectedRecipe
        {
            get { return selectedRecipe; }
            set { 
                selectedRecipe = value;
                OnPropertyChanged(nameof(SelectedRecipe));
            }
        }

        private int recipeId;

        public int RecipeId
        {
            get { return recipeId; }
            set { 
                recipeId = value;
                LoadRecipe(value);
            
            }
        }


        private void LoadRecipe(int id)
        {
            try
            {
                var recipe = _repo.FindRecipe(id);
                SelectedRecipe = recipe;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to load place");
            }
        }


    }
}
