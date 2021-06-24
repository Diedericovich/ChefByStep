using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefByStep.API.Entities
{
    public class Step
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250), MinLength(10)]
        public string Instruction { get; set; }

        public int DurationMin { get; set; }
        public bool IsDone { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}