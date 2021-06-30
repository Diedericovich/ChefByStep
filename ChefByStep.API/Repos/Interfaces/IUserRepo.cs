using ChefByStep.API.Entities;
using ChefByStep.API.Entities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.API.Repos
{
    public interface IUserRepo : IGenericRepo<User>
    {
        Task AddFavouriteRecipe(FavouriteDto favourite);

        Task<List<User>> GetAllAsync();

        Task<User> GetAsync(int id);

        Task<User> GetByNameAsync(string name);

        Task<bool> UserExistsAsync(string name);
    }
}