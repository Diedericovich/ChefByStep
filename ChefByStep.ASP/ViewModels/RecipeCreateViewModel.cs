using ChefByStep.ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.ASP.ViewModels
{
    public class RecipeCreateViewModel
    {
        public int Id { get; set; }
        public int CreatedById { get; set; }

        public Category CategoryId { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }
        public int PrepTimeInMin { get; set; }
        public int CookTimeInMin { get; set; }

        public List<RecipeIngredient> Ingredients { get; set; }

        public List<Step> Steps { get; set; }
    }
}