using ChefByStep.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChefByStep.Services.Repositories
{
    public class MockRecepieRepo : IMockRecipeRepo
    {
        public Recipe FindRecipe(int id)
        {
            var allRecipes = GetAllRecipes();
            Recipe recipe = allRecipes.Find(x => x.Id == id);
            return recipe;
        }

        public List<Recipe> GetAllRecipes()
        {
            List<Recipe> recipes = new List<Recipe>
            {
                new Recipe
                {
                    Id=1,
                    Description = "The sea in your plate",
                    Title= "Sushi",
                    ImgUrl = "pasta.jpg"
                },

                new Recipe
                {
                    Id=2,
                    Description = "Fresh, homemade pasta",
                    Title= "Pasta",
                    ImgUrl = "sushi.jpg",
                },
                new Recipe
                {
                    Id=3,
                    Description = "Napoli style",
                    Title= "Pizza",
                    ImgUrl = "pizza.jpg",
                }
            };

            return recipes;
        }


        //public List<Recipe> GetAllRecipes()
        //{
        //    List<Recipe> recipes = new List<Recipe>
        //       {
        //           new Recipe
        //           {
        //               Id =1,
        //               CategoryID = 1,
        //               Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud",
        //               Title= "Sushi",
        //               ImgUrl = "https://cdn.pixabay.com/photo/2020/04/04/15/07/sushi-5002639_960_720.jpg",
        //               Ingrediants = new List<Ingrediant>
        //               {
        //                   new Ingrediant
        //                   {
        //                       Id=1,
        //                       Name ="Rice",
        //                       Quantity = 1,
        //                       Recipes = new List<Recipe>
        //                       {
        //                           FindRecipe(1)
        //                       }
        //                   }
        //               },
        //               Raitings =new List<RecipeRating>
        //               {
        //                   new RecipeRating
        //                   {
        //                       Id=1,
        //                       Rating=9,
        //                       Comment="Not bad",
        //                       RecipeId = 1,
        //                       UserId = 1
        //                   }
        //               },
        //               Steps = new List<Step>
        //               {
        //                   new Step
        //                   {
        //                       Id=1,
        //                       DurationMin = 34,
        //                       Instruction = "Do this",
        //                       isDone = false
        //                   },
        //                   new Step
        //                   {
        //                       Id=2,
        //                       DurationMin = 34,
        //                       Instruction = "Do that",
        //                       isDone = false
        //                   }
        //               }
        //           },
        //           new Recipe
        //           {
        //               Id =2,
        //               CategoryID = 3,
        //               Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud",
        //               Title= "Pasta",
        //               ImgUrl = "https://cdn.pixabay.com/photo/2016/11/23/18/31/pasta-1854245_960_720.jpg",
        //               Ingrediants = new List<Ingrediant>
        //               {
        //                   new Ingrediant
        //                   {
        //                       Id=2,
        //                       Name ="Pasta",
        //                       Quantity = 1,
        //                       Recipes = new List<Recipe>
        //                       {
        //                           FindRecipe(2)
        //                       }
        //                   },
        //                   new Ingrediant
        //                   {
        //                       Id=3,
        //                       Name ="Tomato",
        //                       Quantity = 1,
        //                       Recipes = new List<Recipe>
        //                       {
        //                           FindRecipe(2)
        //                       }
        //                   }
        //               },
        //               Raitings =new List<RecipeRating>
        //               {
        //                   new RecipeRating
        //                   {
        //                       Id=2,
        //                       Rating=9,
        //                       Comment="Not bad",
        //                       RecipeId = 1,
        //                       UserId = 1
        //                   }
        //               },
        //               Steps = new List<Step>
        //               {
        //                   new Step
        //                   {
        //                       Id=3,
        //                       DurationMin = 39,
        //                       Instruction = "Do this",
        //                       isDone = false
        //                   },
        //                   new Step
        //                   {
        //                       Id=4,
        //                       DurationMin = 34,
        //                       Instruction = "Do that",
        //                       isDone = false
        //                   }
        //               }
        //           }
        //       };
        //    return recipes;
        //}

    }
}
