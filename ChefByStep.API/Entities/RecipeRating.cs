namespace ChefByStep.API.Entities
{
    public class RecipeRating
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RecipeId { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; }
    }
}