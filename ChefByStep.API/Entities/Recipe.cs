using System.Collections.Generic;

namespace ChefByStep.API.Entities
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
    }
}