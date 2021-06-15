namespace ChefByStep.Services.Repositories
{
    using System.Collections.Generic;

    using ChefByStep.Models;

    public class MockRecipeRepo : IMockRecipeRepo
    {
        public List<Recipe> RepoRecipes { get; set; }

        public List<Recipe> RepoSteps { get; set; }

        public Recipe RepoRecipe { get; set; }

        public MockRecipeRepo()
        {
        }

        public Recipe FindRecipe(int id)
        {
            var allRecipes = GetAllRecipes();
            Recipe recipe = allRecipes.Find(x => x.Id == id);
            return recipe;
        }

        public List<Recipe> GetAllRecipes()
        {
            RepoRecipes = new List<Recipe>
                          {
                              new Recipe
                              {
                                  Id = 1,
                                  Description = "The sea in your plate",
                                  Title = "Sushi",
                                  ImgUrl = "sushi.jpg",
                                  Steps = new List<Step>
                                          {
                                              new Step()
                                              {
                                                  DurationMin = 3,
                                                  Id = 1,
                                                  Instruction = "1. Cut up the fish into tiny slices",
                                                  isDone = false,
                                              },
                                              new Step()
                                              {
                                                  DurationMin = 1,
                                                  Id = 2,
                                                  Instruction = "Do step 2. This is step 2",
                                                  isDone = false,
                                              },
                                              new Step()
                                              {
                                                  DurationMin = 1,
                                                  Id = 3,
                                                  Instruction = "Do step 3. This is step 3",
                                                  isDone = false,
                                              },
                                              new Step()
                                              {
                                                  DurationMin = 1,
                                                  Id = 4,
                                                  Instruction = "Do step 4. This is step 4",
                                                  isDone = false,
                                              },
                                          },
                              },

                              new Recipe
                              {
                                  Id = 2,
                                  Description = "Fresh, homemade pasta",
                                  Title = "Pasta",
                                  ImgUrl = "pasta.jpg",
                              },
                              new Recipe
                              {
                                  Id = 3,
                                  Description = "Napoli style",
                                  Title = "Pizza",
                                  ImgUrl = "pizza.jpg",
                              }
                          };

            return RepoRecipes;
        }
    }
}