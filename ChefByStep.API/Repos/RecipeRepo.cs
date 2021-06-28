using ChefByStep.API.Entities;
using ChefByStep.API.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.API.Repos
{
    public class RecipeRepo : GenericRepo<Recipe>, IRecipeRepo
    {
        public RecipeRepo(DatabaseContext context) : base(context)
        {
        }

        public async override Task<Recipe> GetAsync(int id)
        {
            return await _context.Recipes
                .Include(x => x.Ratings)
                .ThenInclude(x => x.User)
                .Include(x => x.Ingredients)
                .ThenInclude(x => x.Ingredient)
                .Include(x => x.Steps)
                .Include(x => x.CreatedBy)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async override Task<List<Recipe>> GetAllAsync()
        {
            return await _context.Recipes
                .Include(x => x.Ratings)
                .ToListAsync();
        }

        public async Task<List<Recipe>> GetAllByCategory(int categoryId)
        {
            return await _context.Recipes
                .Where(x => x.CategoryId == categoryId)
                .Include(x => x.Ratings)
                .ToListAsync();
        }
    }
}