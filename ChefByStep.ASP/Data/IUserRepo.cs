using ChefByStep.ASP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.ASP.Data
{
    public interface IUserRepo
    {
        Task<ApiUser> GetUserAsync(int id);
        Task<IList<ApiUser>> GetUsersAsync();
    }
}