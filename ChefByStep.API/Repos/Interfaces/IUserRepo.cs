using ChefByStep.API.Entities;
using System.Threading.Tasks;

namespace ChefByStep.API.Repos
{
    public interface IUserRepo : IGenericRepo<User>
    {
        Task<bool> UserExistsAsync(string name);

        Task<User> GetByNameAsync(string name);
    }
}