using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.API.Entities
{
    public class RecipeIngredient
    {
        public int Id { get; set; }

        [Required]
        public int IngredientId { get; set; }

        [Required]
        public int RecipeId { get; set; }

        [MaxLength(50)]
        public string Amount { get; set; }

        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}