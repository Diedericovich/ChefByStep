using ChefByStep.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChefByStep.API.Helpers
{
    public static class ModelBuilderExtensions
    {
        public static void BuildRelations(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeRating>()
                .HasKey(x => new { x.UserId, x.RecipeId });
            modelBuilder.Entity<RecipeRating>()
                .HasOne<User>(x => x.User)
                .WithMany(x => x.Ratings)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<RecipeRating>()
                .HasOne<Recipe>(x => x.Recipe)
                .WithMany(x => x.Ratings)
                .HasForeignKey(x => x.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Recipe>()
                .HasOne(x => x.CreatedBy)
                .WithMany(x => x.CreatedRecipes)
                .HasForeignKey(x => x.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Recipe>()
                .HasMany(x => x.CompletedBy)
                .WithMany(x => x.CompletedRecipes)
                .UsingEntity(x => x.ToTable("UserCompletedRecipes"));
            modelBuilder.Entity<Recipe>()
                .HasMany(x => x.FavouritedBy)
                .WithMany(x => x.FavoriteRecipes)
                .UsingEntity(x => x.ToTable("UserFavouriteRecipes"));
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                DataSeeder.GetUsers()
                );
            modelBuilder.Entity<Step>().HasData(
                DataSeeder.GetStepsFromCsv()
                );
            modelBuilder.Entity<Recipe>().HasData(
                DataSeeder.GetRecipesFromCsv()
                );
            modelBuilder.Entity<Ingredient>().HasData(
                DataSeeder.GetIngredientsFromCsv()
                );
            modelBuilder.Entity<RecipeIngredient>().HasData(
                DataSeeder.GetRecipeIngredients()
                );
        }
    }
}