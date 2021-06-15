using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.API.Repos
{
    public interface IGenericRepo<T>
    {
        Task AddAsync(T item);
        Task DeleteAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task UpdateAsync(T item);
    }
}