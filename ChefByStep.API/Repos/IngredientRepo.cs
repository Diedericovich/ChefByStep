using ChefByStep.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.API.Repos.Interfaces
{
    public class IngredientRepo : GenericRepo<Ingredient>, IIngredientRepo
    {
        public IngredientRepo(DatabaseContext context) : base(context)
        {

        }
        public override async Task<Ingredient> GetAsync(int id)
        {
            return await _context.Ingredients
                    .Include(x => x.Recipes)
                    .FirstOrDefaultAsync(x => x.Id == id);
        }
        public override async Task<List<Ingredient>> GetAllAsync()
        {
            return await _context.Ingredients
                    .Include(x => x.Recipes)
                    .ToListAsync();
        }
    }
}
