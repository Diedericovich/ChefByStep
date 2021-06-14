using ChefByStep.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.API.Repos
{
    public interface IRecipeRepo
    {
        Task<List<Recipe>> GetAllAsync();
        Task<Recipe> GetAsync(int id);
    }
}