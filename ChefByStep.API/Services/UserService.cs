﻿using ChefByStep.API.Entities;
using ChefByStep.API.Repos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.API.Services
{
    public class UserService : IUserService
    {
        private IUserRepo _repo;

        public UserService(IUserRepo repo)
        {
            _repo = repo;
        }
        public async Task AddUserAsync(User user)
        {
            await _repo.AddAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _repo.GetAsync(id);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            await _repo.UpdateAsync(user);
        }
    }
}