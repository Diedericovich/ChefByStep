using ChefByStep.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.API.Repos.Interfaces
{
    public class RecipeRatingRepo : GenericRepo<RecipeRating>, IRecipeRatingRepo
    {
        public RecipeRatingRepo(DatabaseContext context) : base(context)
        {
        }

        public override async Task<RecipeRating> GetAsync(int id)
        {
            //return await _context.RecipeRatings
            //        .Include(x => x.UserId)
            //        .Include(x => x.RecipeId)
            //        .FirstOrDefaultAsync(x => x.Id == id);
            throw new NotImplementedException();
        }

        public override async Task<List<RecipeRating>> GetAllAsync()
        {
            return await _context.RecipeRatings
                    .Include(x => x.UserId)
                    .Include(x => x.RecipeId)
                    .ToListAsync();
        }
    }
}