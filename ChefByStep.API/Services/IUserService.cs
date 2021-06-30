using ChefByStep.API.Entities;
using ChefByStep.API.Entities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.API.Services
{
    public interface IUserService
    {
        Task AddFavouriteRecipe(FavouriteDto favourite);
        Task AddUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserAsync(int id);
        Task<User> GetUserByNameAsync(string name);
        Task UpdateUserAsync(User user);
        Task<bool> UserExistsAsync(string name);
    }
}