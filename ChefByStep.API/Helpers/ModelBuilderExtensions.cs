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
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            BuildRecipes(modelBuilder);
        }

        private static void BuildRecipes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>().HasData(
                new Recipe
                {
                    Id = 1,
                    CategoryId = 1,
                    Title = "Pasta Bolognese",
                    Description = "paghetti bolognese consists of spaghetti (long strings of pasta) with an Italian ragù (meat sauce) made with minced beef, bacon and tomatoes, served with Parmesan cheese. Spaghetti bolognese is one of the most popular pasta dishes eaten outside of Italy.",
                    ImageUrl = "https://placekitten.com/200/300",
                    CreatedById = 1
                }
                );

            modelBuilder.Entity<Step>().HasData(
                new Step
                { Id = 1, DurationMin = 0, Instruction = "step1", IsDone = false },
                new Step
                { Id = 2, DurationMin = 0, Instruction = "step2", IsDone = false }
                );
        }
    }
}