using ChefByStep.ASP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.ASP.Services
{
    public interface IUserService
    {
        Task<ApiUser> GetUserAsync(int id);
        Task<IList<ApiUser>> GetUsersAsync();
    }
}