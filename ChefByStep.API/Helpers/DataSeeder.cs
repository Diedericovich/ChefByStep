using ChefByStep.API.Entities;
using ChefByStep.API.Repos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.API.Helpers
{
    public class DataSeeder
    {
        internal DatabaseContext _context;

        public DataSeeder(DatabaseContext context)
        {
            _context = context;
        }

        public static void SeedRecipes(DatabaseContext context)
        {
            User tempuser = new User
            {
                Name = "test"
            };
            context.Add(tempuser);
            context.SaveChanges();

            string[] lines = File.ReadAllLines("Helpers\\Datafiles\\clean_recipes.csv").Skip(1).ToArray();
            for (int i = 0; i < 10; i++)
            {
                var line = lines[i].Split(';');
                Recipe temp = new Recipe
                {
                    ImageUrl = line[2],
                    Title = line[0],
                    Ingredients = new List<Ingredient>(),
                    Steps = new List<Step>(),
                    CreatedById = 1
                };
                string[] ingredients = line[7].Split(',').ToArray();
                foreach (var item in ingredients)
                {
                    temp.Ingredients.Add(new Ingredient { Name = item });
                }
                string[] steps = line[8].Split('.').ToArray();
                foreach (var item in steps)
                {
                    temp.Steps.Add(new Step { Instruction = item });
                }

                context.Add(temp);
                context.SaveChanges();
            }
        }
    }
}