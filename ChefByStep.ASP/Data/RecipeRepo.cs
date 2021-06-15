using ChefByStep.ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.ASP.Data
{

    public class RecipeRepo : IRecipeRepo
    {
        private ApplicationDbContext _context;
        public RecipeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Recipe> GetRecipeAsync(int id)
        {
            Recipe recipe = await _context.Recipes.FindAsync(id);
            return recipe;
        }
    }
}
