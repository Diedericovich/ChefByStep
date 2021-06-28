using ChefByStep.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.API.Repos
{
    public interface IRecipeRepo : IGenericRepo<Recipe>
    {
        Task<List<Recipe>> GetAllAsync();

        Task<List<Recipe>> GetAllByCategory(int categoryId);

        Task<Recipe> GetAsync(int id);

        Task<List<Recipe>> GetBySearchAsync(string searchText);
    }
}