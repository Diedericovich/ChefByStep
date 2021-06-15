using ChefByStep.API.Entities;
using ChefByStep.API.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.API.Services
{
    public class StepService : IStepService
    {
        private IGenericRepo<Step> _repo;

        public StepService(IGenericRepo<Step> repo)
        {
            _repo = repo;
        }

        public async Task AddStepAsync(Step step)
        {
            await _repo.AddAsync(step);
        }

        public async Task DeleteStepAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
        public async Task<Step> GetStepAsync(int id)
        {
            return await _repo.GetAsync(id);
        }
        public async Task<List<Step>> GetAllStepsAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task UpdateStepAsync(Step step)
        {
            await _repo.UpdateAsync(step);
        }
    }
}
