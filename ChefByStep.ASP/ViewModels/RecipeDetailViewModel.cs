using ChefByStep.ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.ASP.ViewModels
{
    public class RecipeDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<Step> Steps { get; set; }
        public List<RecipeIngredient> Ingredients { get; set; }
        public List<RecipeRating> Ratings { get; set; }
    }
}
