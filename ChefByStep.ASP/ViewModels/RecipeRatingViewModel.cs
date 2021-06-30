namespace ChefByStep.ASP.ViewModels
{
    using ChefByStep.ASP.Models;

    public class RecipeRatingViewModel

    {
        public int UserId { get; set; }

        public int RecipeId { get; set; }

        public ApiUser User { get; set; }

        public Recipe Recipe { get; set; }

        public string Comment { get; set; }

        public double Rating { get; set; }
    }
}