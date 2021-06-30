using ChefByStep.API.Entities;
using ChefByStep.API.Entities.DTOs;
using ChefByStep.API.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChefByStep.API.Repos
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        public UserRepo(DatabaseContext context) : base(context)
        {
        }

        public override async Task<User> GetAsync(int id)
        {
            return await _context.Users
                .Include(x => x.CompletedRecipes)
                .Include(x => x.FavoriteRecipes)
                .Include(x => x.CreatedRecipes)
                .Include(x => x.Ratings)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<List<User>> GetAllAsync()
        {
            return await _context.Users
                .Include(x => x.CompletedRecipes)
                .Include(x => x.FavoriteRecipes)
                .Include(x => x.CreatedRecipes)
                .Include(x => x.Ratings)
                .ToListAsync();
        }

        public async Task<User> GetByNameAsync(string name)
        {
            return await _context.Users
                .Include(x => x.CompletedRecipes)
                .Include(x => x.FavoriteRecipes)
                .Include(x => x.CreatedRecipes)
                .Include(x => x.Ratings)
                .FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<bool> UserExistsAsync(string name)
        {
            return await _context.Users
                .AnyAsync(x => x.Name == name);
        }

        public async Task AddFavouriteRecipe(FavouriteDto favourite)
        {
            var commandText = @"INSERT INTO UserFavouriteRecipes(FavoriteRecipesId,FavouritedById) VALUES(@RecipeId,@UserId)";
            var recepiId = new SqlParameter("@RecipeId", favourite.RecipeId);
            var userId = new SqlParameter("@UserId", favourite.UserId);
            await _context.Database.ExecuteSqlRawAsync(commandText, recepiId, userId);
        }
    }
}