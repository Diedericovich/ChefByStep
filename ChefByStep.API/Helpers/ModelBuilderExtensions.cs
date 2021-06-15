using ChefByStep.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ChefByStep.API.Helpers
{
    public static class ModelBuilderExtensions
    {
        public static void BuildRelations(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.CompletedRecipes)
                .WithMany(x => x.CompletedBy)
                .UsingEntity(x => x.ToTable("UserCompletedRecipe"));
            modelBuilder.Entity<User>()
                .HasMany(x => x.FavoriteRecipes)
                .WithMany(x => x.FavouritedBy)
                .UsingEntity(x => x.ToTable("UserFavouritedRecipe"));
            modelBuilder.Entity<RecipeRating>()
                .HasKey(x => new { x.UserId, x.RecipeId });
            modelBuilder.Entity<RecipeRating>()
                .HasOne<User>(x => x.User)
                .WithMany(x => x.Rating)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<RecipeRating>()
                .HasOne<Recipe>(x => x.Recipe)
                .WithMany(x => x.Ratings)
                .HasForeignKey(x => x.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            BuildRecipes(modelBuilder);
        }

        private static void BuildRecipes(ModelBuilder modelBuilder)
        {
        }
    }
}