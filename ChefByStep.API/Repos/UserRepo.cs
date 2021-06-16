using ChefByStep.API.Entities;
using ChefByStep.API.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.API.Repos
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        public UserRepo(DatabaseContext context) : base(context)
        {
            DataSeeder.SeedRecipes(context);
        }

        public override async Task<User> GetAsync(int id)
        {
            return await _context.Users
                .Include(x => x.CompletedRecipes)
                .Include(x => x.FavoriteRecipes)
                .Include(x => x.CreatedRecipe)
                .Include(x => x.Rating)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<List<User>> GetAllAsync()
        {
            return await _context.Users
                .Include(x => x.CompletedRecipes)
                .Include(x => x.FavoriteRecipes)
                .Include(x => x.CreatedRecipe)
                .Include(x => x.Rating)
                .ToListAsync();
        }
    }
}