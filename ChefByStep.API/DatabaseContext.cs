using ChefByStep.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.API
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeRating> RecipeRatings { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<User> Users { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.CompletedRecipes)
                .WithMany(x => x.CompletedBy)
                .UsingEntity(x => x.ToTable("UserCompletedRecipe"));
            modelBuilder.Entity<User>()
                .HasMany(x => x.FavoriteRecipes)
                .WithMany(x => x.FavouritedBy)
                .UsingEntity(x => x.ToTable("UserFavouritedRecipe"));
        }
    }
}