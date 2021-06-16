using ChefByStep.API.Entities;
using ChefByStep.API.Helpers;
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
                    .FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<List<Ingredient>> GetAllAsync()
        {
            return await _context.Ingredients
                    .ToListAsync();
        }
    }
}