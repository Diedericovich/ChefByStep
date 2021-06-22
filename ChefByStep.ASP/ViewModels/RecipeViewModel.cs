namespace ChefByStep.ASP.ViewModels
{
    using System.Collections.Generic;

    using ChefByStep.ASP.Models;

    public class RecipeViewModel
    {
        public ICollection<Recipe> Recipes { get; set; }
    }
}
