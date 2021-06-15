using ChefByStep.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.API.Services
{
    public interface IStepService
    {
        Task AddStepAsync(Step step);
        Task DeleteStepAsync(int id);
        Task<List<Step>> GetAllStepsAsync();
        Task<Step> GetStepAsync(int id);
        Task UpdateStepAsync(Step step);
    }
}