using ChefByStep.API.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChefByStep.API.Helpers
{
    public class DataSeeder
    {
        public DataSeeder()
        {
            string[] lines = File.ReadAllLines("Helpers\\Datafiles\\Recipes.csv").Skip(1).ToArray();
        }

        public static List<Recipe> GetRecipesFromCsv()
        {
            string[] lines = File.ReadAllLines("Helpers\\Datafiles\\Recipes.csv").Skip(1).ToArray();
            var rand = new Random();
            List<Recipe> recipes = new List<Recipe>();
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i].Split(';');
                recipes.Add(
                    new Recipe
                    {
                        Id = i + 1,
                        ImageUrl = line[2],
                        Title = line[0],
                        Steps = new List<Step>(),
                        Description = line[4],
                        CreatedById = rand.Next(1, 5)
                    });
            }
            return recipes;
        }

        public static List<RecipeIngredient> GetRecipeIngredients()
        {
            string[] lines = File.ReadAllLines("Helpers\\Datafiles\\Recipes.csv").Skip(1).ToArray();
            int counter = 0;
            List<RecipeIngredient> recipeIngredients = new List<RecipeIngredient>();
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i].Split(';');
                string[] ingredientlines = line[3].Split('|').Distinct().ToArray();
                for (int j = 0; j < ingredientlines.Length; j++)
                {
                    counter++;

                    string[] ingredient = ingredientlines[j].Split(',').Distinct().ToArray();
                    if (ingredient.Length > 1)
                    {
                        //ingredients.Add(ingredient[1].Trim().ToLower());
                        var id = GetIngredientsFromCsv().FirstOrDefault(x => x.Name == ingredient[1].Trim().ToLower());
                        recipeIngredients.Add(new RecipeIngredient
                        {
                            Id = counter,
                            RecipeId = i + 1,
                            IngredientId = id.Id,
                            Amount = ingredient[0]
                        }); ;
                    }
                    else
                    {
                        //ingredients.Add(ingredient[0].Trim().ToLower());
                        var id = GetIngredientsFromCsv().FirstOrDefault(x => x.Name == ingredient[0].Trim().ToLower());
                        recipeIngredients.Add(new RecipeIngredient
                        {
                            Id = counter,
                            RecipeId = i + 1,
                            IngredientId = id.Id,
                            Amount = ""
                        });
                    }
                }
            }
            return recipeIngredients;
        }

        public static List<User> GetUsers()
        {
            string[] lines = File.ReadAllLines("Helpers\\Datafiles\\Recipes.csv").Skip(1).ToArray();
            List<User> users = new List<User>
            {
                new User{Id = 1, Name = "Frieda", },
                new User{Id = 2,Name = "Alberto",},
                new User{Id = 3,Name = "Octaaf",},
                new User{Id = 4,Name = "Gert",},
            };
            return users;
        }

        public static List<Step> GetStepsFromCsv()
        {
            int idcounter = 0;
            string[] lines = File.ReadAllLines("Helpers\\Datafiles\\Recipes.csv").Skip(1).ToArray();
            var steps = new List<Step>();
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i].Split(';');
                string[] steplines = line[5].Split('|').Distinct().ToArray();
                for (int j = 0; j < steplines.Length; j++)
                {
                    idcounter++;
                    steps.Add(new Step { Instruction = steplines[j].Trim(), Id = idcounter });
                }
            }
            return steps;
        }

        public static List<Ingredient> GetIngredientsFromCsv()
        {
            int idcounter = 0;
            string[] lines = File.ReadAllLines("Helpers\\Datafiles\\Recipes.csv").Skip(1).ToArray();
            var ingredients = new List<string>();
            var ingredientList = new List<Ingredient>();
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i].Split(';');
                string[] ingredientlines = line[3].Split('|').Distinct().ToArray();
                for (int j = 0; j < ingredientlines.Length; j++)
                {
                    string[] ingredient = ingredientlines[j].Split(',').Distinct().ToArray();
                    if (ingredient.Length > 1)
                    {
                        ingredients.Add(ingredient[1].Trim().ToLower());
                    }
                    else
                    {
                        ingredients.Add(ingredient[0].Trim().ToLower());
                    }
                }
            }
            IEnumerable<string> distinct = ingredients.Distinct();
            foreach (var item in distinct)
            {
                idcounter++;
                ingredientList.Add(new Ingredient { Id = idcounter, Name = item });
            }
            return ingredientList;
        }

        public static List<RecipeRating> GetRecipeRatings()
        {
            List<RecipeRating> ratings = new List<RecipeRating>()
            {
                new RecipeRating
                {
                    UserId = 1,
                    RecipeId = 1,
                    Comment = "Verrrrrrrrry sweet",
                    Rating = 10.0,
                },
                new RecipeRating
                {
                    UserId = 1,
                    RecipeId = 2,
                    Comment = "Awful sweet",
                    Rating = 10.0,
                },
            };
            return ratings;
        }

        //public static void SeedRecipes(DatabaseContext context)
        //{
        //    if (!context.Recipes.Any())
        //    {
        //        User tempuser = new User
        //        {
        //            Name = "test"
        //        };
        //        context.Add(tempuser);
        //        context.SaveChanges();

        //        string[] lines = File.ReadAllLines("Helpers\\Datafiles\\Recipes.csv").Skip(1).ToArray();
        //        for (int i = 0; i < lines.Length; i++)
        //        {
        //            var line = lines[i].Split(';');
        //            Recipe temp = new Recipe
        //            {
        //                ImageUrl = line[2],
        //                Title = line[0],
        //                Steps = new List<Step>(),

        //                Description = line[4],
        //                CreatedById = 1
        //            };
        //            string[] ingredients = line[3].Split('|').ToArray();
        //            foreach (var item in ingredients)
        //            {
        //                //temp.Ingredients.Add(new Ingredient { Name = item });
        //            }
        //            string[] steps = line[5].Split('|').ToArray();
        //            foreach (var item in steps)
        //            {
        //                temp.Steps.Add(new Step { Instruction = item });
        //            }

        //            context.Update(temp);
        //            context.SaveChanges();
        //        }
        //    }
        //}
    }
}