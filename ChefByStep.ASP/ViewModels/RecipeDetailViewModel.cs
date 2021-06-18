using ChefByStep.ASP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChefByStep.ASP.ViewModels
{
    [BindProperties]
    public class RecipeDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<Step> Steps { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<RecipeRating> Ratings { get; set; }
    }
}