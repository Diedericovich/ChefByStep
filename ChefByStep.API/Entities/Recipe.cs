using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefByStep.API.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public int CreatedById { get; set; }
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(75), MinLength(5)]
        public string Title { get; set; }

        [Required]
        [MaxLength(150), MinLength(5)]
        public string Description { get; set; }

        [Required]
        [MaxLength(150), MinLength(5)]
        public string ImageUrl { get; set; }

        public int PrepTimeInMin { get; set; }
        public int CookTimeInMin { get; set; }
        public List<RecipeRating> Ratings { get; set; }
        public List<RecipeIngredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }
        public User CreatedBy { get; set; }
        public List<User> FavouritedBy { get; set; }
        public List<User> CompletedBy { get; set; }
    }
}