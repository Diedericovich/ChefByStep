namespace ChefByStep.ASP.ViewModels
{
    using System.Collections.Generic;

    using ChefByStep.ASP.Models;

    public class RecipeDetailViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
        public string CreatedByUser { get; set; }
        public int PrepTimeInMin { get; set; }
        public int CookTimeInMin { get; set; }

        public List<Step> Steps { get; set; }

        public List<RecipeIngredient> Ingredients { get; set; }

        public List<RecipeRating> Ratings { get; set; }
    }
}