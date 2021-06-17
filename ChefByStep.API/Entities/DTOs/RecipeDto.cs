using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.API.Entities.DTOs
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<RecipeRating> Ratings { get; set; }
        public List<Recipe> Ingredients { get; set; }
        public List<Step> Steps { get; set; }
        public List<User> FavouritedBy { get; set; }
        public List<User> CompletedBy { get; set; }
    }
}