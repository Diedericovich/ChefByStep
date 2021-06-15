namespace ChefByStep.API.Repos
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ChefByStep.API.Entities;
    using ChefByStep.API.Helpers;

    using Microsoft.EntityFrameworkCore;

    public class RecipeRepo : GenericRepo<Recipe>, IRecipeRepo
    {
        public RecipeRepo(DatabaseContext context) : base(context)
        {
            DataSeeder.SeedRecipes(context);
        }

        public override Task<Recipe> GetAsync(int id)
        {
            return _context.Recipes
                .Include(x => x.CreatedBy)
                .Include(x => x.Ratings)
                .Include(x => x.Ingredients)
                .Include(x => x.Steps)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public override Task<List<Recipe>> GetAllAsync()
        {
            return _context.Recipes
                .Include(x => x.Ratings)
                .Include(x => x.Ingredients)
                .Include(x => x.Steps)
                .ToListAsync();
        }
    }
}