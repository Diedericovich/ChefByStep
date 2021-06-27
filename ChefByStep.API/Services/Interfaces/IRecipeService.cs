﻿using ChefByStep.API.Entities;
using ChefByStep.API.Entities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.API.Services
{
    public interface IRecipeService
    {
        Task AddRecipeAsync(Recipe recipe);
        Task DeleteRecipeAsync(int id);
        Task<IEnumerable<Recipe>> GetAllByCategory(int categoryId);
        Task<IEnumerable<Recipe>> GetAllBySearch(string searchText);
        Task<List<Recipe>> GetAllRecipesAsync();
        Task<RecipeDto> GetRecipeAsync(int id);
        Task UpdateRecipeAsync(Recipe recipe);
    }
}