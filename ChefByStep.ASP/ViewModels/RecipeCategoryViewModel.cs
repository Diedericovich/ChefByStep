namespace ChefByStep.ASP.ViewModels
{
    using System.Collections.Generic;

    using ChefByStep.ASP.Models;

    public class RecipeCategoryViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public Category RecipeCategory { get; set; }
    }
}