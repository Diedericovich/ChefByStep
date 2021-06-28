namespace ChefByStep.ASP.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ChefByStep.ASP.Models;

    public class RecipeViewModel
    {
        public ICollection<Recipe> Recipes { get; set; }
    }
}