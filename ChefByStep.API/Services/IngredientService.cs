using ChefByStep.API.Entities;
using ChefByStep.API.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.API.Services
{
    public class IngredientService : IIngredientService
    {
        private IIngredientRepo _repo;

        public IngredientService(IIngredientRepo repo)
        {
            _repo = repo;
        }

        public async Task AddIngredientAsync(Ingredient ingredient)
        {
            await _repo.AddAsync(ingredient);
        }

        public async Task DeleteIngredientAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<List<Ingredient>> GetAllIngredientsAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Ingredient> GetIngredientAsync(int id)
        {
            return await _repo.GetAsync(id);
        }

        public async Task UpdateIngredientAsync(Ingredient ingredient)
        {
            await _repo.UpdateAsync(ingredient);
        }
    }
}
