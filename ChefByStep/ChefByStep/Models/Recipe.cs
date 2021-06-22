namespace ChefByStep.Models
{
    using System.Collections.Generic;

    public class Recipe : BaseModel
    {
        public int CategoryID { get; set; }

        public string Description { get; set; }

        public List<RecipeRating> Ratings { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public List<RecipeIngredient> Ingredients { get; set; }

        public List<Step> Steps { get; set; }

    }
}
