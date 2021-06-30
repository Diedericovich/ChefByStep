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
                        CategoryId = Convert.ToInt32(line[1]),
                        ImageUrl = line[2],
                        Title = line[0],
                        PrepTimeInMin = Convert.ToInt32(line[6]),
                        CookTimeInMin = Convert.ToInt32(line[7]),
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
                new User{Id = 1, Name = "Simon Van Tittelboom", },
                new User{Id = 2,Name = "Jens Van Gelder",},
                new User{Id = 3,Name = "Emma Danckaert",},
                new User{Id = 4,Name = "Diederik Van Yperzele",},
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
                    steps.Add(new Step { Instruction = steplines[j].Trim(), Id = idcounter, RecipeId = i + 1 });
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
                new RecipeRating{RecipeId = 1,UserId = 1,Comment = "Loved it! The lemon juice really added a nice kick to the recipe.",Rating = 5,},
                new RecipeRating{RecipeId = 1,UserId = 2,Comment = "Great taste and easy to make.",Rating = 4,},
                new RecipeRating{RecipeId = 1,UserId = 3,Comment = "I liked it, but next time I'm gonig to try it without the horseradish!",Rating = 3,},

                new RecipeRating{RecipeId = 2,UserId = 1,Comment = "I've been making this to eat at work during lunchtime. Tasty and takes almost no effort to make.",Rating = 4,},

                new RecipeRating{RecipeId = 3,UserId = 4,Comment = "Tastes like the one my mother used to make.",Rating = 5,},

                new RecipeRating{RecipeId = 4,UserId = 2,Comment = "Tastes like the one my mother used to make.",Rating = 5,},
                new RecipeRating{RecipeId = 4,UserId = 3,Comment = "Good Bread.",Rating = 3,},

                new RecipeRating{RecipeId = 6,UserId = 3,Comment = "Very tasty and quick to make.",Rating = 5,},
                new RecipeRating{RecipeId = 6,UserId = 4,Comment = "Good Bread.",Rating = 3,},
            };
            return ratings;
        }
    }
}