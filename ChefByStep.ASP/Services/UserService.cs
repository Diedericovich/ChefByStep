namespace ChefByStep.ASP.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ChefByStep.ASP.Data;
    using ChefByStep.ASP.Models;

    public class UserService : IUserService
    {
        private IUserRepo _repo;

        public UserService(IUserRepo repo)
        {
            _repo = repo;
        }

        public async Task<IList<ApiUser>> GetUsersAsync()
        {
            IList<ApiUser> users = await _repo.GetUsersAsync();
            return users;
        }

        public async Task<ApiUser> GetUserAsync(int id)
        {
            var user = await _repo.GetUserAsync(id);
            return user;
        }

        public async Task<ApiUser> GetUserByNameAsync(string name)
        {
            var user = await _repo.GetUserByNameAsync(name);
            return user;
        }

        public async Task PostUser(ApiUser user)
        {
            await _repo.PostUserAsync(user);
        }
    }
}