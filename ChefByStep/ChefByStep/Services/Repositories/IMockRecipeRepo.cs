namespace ChefByStep.Services.Repositories
{
    using System.Collections.Generic;

    using ChefByStep.Models;

    public interface IMockRecipeRepo
    {
        Recipe FindRecipe(int id);

        List<Recipe> GetAllRecipes();
    }
}