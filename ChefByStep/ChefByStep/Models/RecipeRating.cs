namespace ChefByStep.Models
{
    public class RecipeRating : BaseModel
    {
        public int UserId { get; set; }

        public int RecipeId { get; set; }

        public double Rating { get; set; }

        public string Comment { get; set; }
        public User User { get; set; }
    }
}