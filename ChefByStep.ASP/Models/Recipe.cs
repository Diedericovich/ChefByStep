﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.ASP.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public List<RecipeRating> Ratings { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        public List<ApplicationUser> FavouritedBy { get; set; }
        public List<ApplicationUser> CompletedBy { get; set; }
    }
}