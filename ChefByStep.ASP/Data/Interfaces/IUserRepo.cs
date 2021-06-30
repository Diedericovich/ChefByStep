using ChefByStep.ASP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.ASP.Data
{
    public interface IUserRepo
    {
        Task AddFavouriteRecipe(FavouriteDto favourite);
        Task<ApiUser> GetUserAsync(int id);
        Task<ApiUser> GetUserByNameAsync(string name);
        Task<IList<ApiUser>> GetUsersAsync();
        Task PostUserAsync(ApiUser user);
        Task UpdateUserAsync(ApiUser user);
    }
}