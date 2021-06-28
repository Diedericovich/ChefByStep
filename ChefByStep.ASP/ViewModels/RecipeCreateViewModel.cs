using ChefByStep.ASP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.ASP.ViewModels
{
    public class RecipeCreateViewModel
    {
        public int Id { get; set; }
        public int CreatedById { get; set; }

        [DisplayName("Category: ")]
        public Category CategoryId { get; set; }

        public string Description { get; set; }

        [DisplayName("Image Link: ")]
        public string ImageUrl { get; set; }

        public string Title { get; set; }
        [DisplayName("Preparation Time (in minutes): ")]
        public int PrepTimeInMin { get; set; }
        [DisplayName("Cooking Time (in minutes): ")]
        public int CookTimeInMin { get; set; }

        public List<Step> Steps { get; set; }

        public List<RecipeIngredient> Ingredients { get; set; }
        public ApiUser CreatedBy { get; set; }

    }
}