namespace ChefByStep.Services.Repositories
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using ChefByStep.Models;

    public interface IMockRecipeRepo
    {
        List<Recipe> RepoRecipes { get; set; }

        List<Recipe> RepoSteps { get; set; }

        Recipe RepoRecipe { get; set; }

        Task<Recipe> FindRecipe(int id);

        Task<Recipe> GetRecipeAsync(int id);

        Task<IList<Recipe>> GetAllRecipes();

        Task<HttpResponseMessage> GetHttpResponseMessageAsync(string url);

        Task<Recipe> GetEntityFromJsonAsync(HttpResponseMessage message);

        Task<List<Recipe>> GetEntitiesFromJsonAsync(HttpResponseMessage message);

        string GenerateUrl(int id);
    }
}