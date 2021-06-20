using ChefByStep.API.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.API.Services
{
    public interface IUserService
    {
        Task AddUserAsync(User user);

        Task DeleteUserAsync(int id);

        Task<List<User>> GetAllUsersAsync();

        Task<User> GetUserAsync(int id);

        Task UpdateUserAsync(User user);

        Task<bool> UserExistsAsync(string name);

        Task<User> GetUserByNameAsync(string name);
    }
}