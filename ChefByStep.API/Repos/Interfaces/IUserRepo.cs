using ChefByStep.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.API.Repos
{
    public interface IUserRepo
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetAsync(int id);
    }
}