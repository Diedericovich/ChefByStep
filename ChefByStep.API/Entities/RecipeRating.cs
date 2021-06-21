namespace ChefByStep.API.Entities
{
    public class RecipeRating
    {
        public int UserId { get; set; }
        public int RecipeId { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; }
        public User User { get; set; }
        public Recipe Recipe { get; set; }
    }
}