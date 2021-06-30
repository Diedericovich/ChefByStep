﻿namespace ChefByStep.API.Entities.DTOs
{
    public class RecipeIngredientDto
    {
        public int Id { get; set; }

        public int IngredientId { get; set; }

        public int RecipeId { get; set; }

        public string Amount { get; set; }

        public IngredientDto Ingredient { get; set; }
    }
}