using ChefByStep.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.API.Services
{
    public interface IUserService
    {
        Task AddUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<User> GetUserAsync(int id);
        Task<List<User>> GetUsersAsync();
        Task UpdateUserAsync(User user);
    }
}