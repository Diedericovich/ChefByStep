using ChefByStep.ASP.Models;
using System.Threading.Tasks;

namespace ChefByStep.ASP.Services
{
    public interface IRecipeService
    {
        Task<Recipe> GetRecipeAsync(int id);
    }
}