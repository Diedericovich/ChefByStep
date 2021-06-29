namespace ChefByStep.API.Repos
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        public DatabaseContext _context;

        public GenericRepo(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T item)
        {
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await GetAsync(id);
            _context.Remove(item);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await _context.FindAsync<T>(id);
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task UpdateAsync(T item)
        {
            //_context.Attach(item);
            _context.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}