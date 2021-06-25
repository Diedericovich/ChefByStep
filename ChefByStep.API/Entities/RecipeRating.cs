using System.ComponentModel.DataAnnotations;

namespace ChefByStep.API.Entities
{
    public class RecipeRating
    {
        public int UserId { get; set; }

        public int RecipeId { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        [Range(1, 5)]
        public double Rating { get; set; }

        public User User { get; set; }

        public Recipe Recipe { get; set; }
    }
}