using ChefByStep.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.API.Services
{
    public interface IIngredientService
    {
        Task AddIngredientAsync(Ingredient ingredient);
        Task DeleteIngredientAsync(int id);
        Task<List<Ingredient>> GetAllIngredientsAsync();
        Task<Ingredient> GetIngredientAsync(int id);
        Task UpdateIngredientAsync(Ingredient ingredient);
    }
}