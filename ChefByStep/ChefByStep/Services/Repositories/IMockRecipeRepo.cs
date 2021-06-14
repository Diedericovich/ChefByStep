using ChefByStep.Models;
using System.Collections.Generic;

namespace ChefByStep.Services.Repositories
{
    public interface IMockRecipeRepo
    {
        Recipe FindRecipe(int id);
        List<Recipe> GetAllRecipes();
    }
}