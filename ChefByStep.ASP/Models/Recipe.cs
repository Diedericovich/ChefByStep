﻿namespace ChefByStep.ASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;

    public class Recipe
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }

        public List<RecipeRating> Ratings { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public List<RecipeIngredient> Ingredients { get; set; }

        public List<Step> Steps { get; set; }

        [NotMapped]
        public ApplicationUser CreatedBy { get; set; }

        [NotMapped]
        public List<ApplicationUser> FavouritedBy { get; set; }

        [NotMapped]
        public List<ApplicationUser> CompletedBy { get; set; }
    }
}