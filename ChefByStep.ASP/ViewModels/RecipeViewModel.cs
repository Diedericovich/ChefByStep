using ChefByStep.ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.ASP.ViewModels
{
    public class RecipeViewModel
    {
        public ICollection<Recipe> Recipes { get; set; }
    }
}
