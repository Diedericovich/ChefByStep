using ChefByStep.ASP.Data;
using ChefByStep.ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.ASP.Services
{
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

        //public async Task PostUser(ApiUser user)
        //{
        //    await _rep
        //}
    }
}