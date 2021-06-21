namespace ChefByStep.Services.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using ChefByStep.Models;

    using Newtonsoft.Json;

    public class RecipeRepository : IRecipeRepository
    {
         private const string baseUrl = "https://10.0.2.2:44350/api/Recipe";
        //private const string baseUrl = "https://chefbystepapimgmt.azure-api.net/api/api/Recipe";

        public async Task<Recipe> GetRecipe(int id)
        {
            var url = $"{baseUrl}/{id}";
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback += (sender, certificate, chain, errors) => true;

            using (var client = new HttpClient(handler))
            {
                try
                {
                    HttpResponseMessage message = await client.GetAsync(url);

                    if (message.IsSuccessStatusCode)
                    {
                        string json = await message.Content.ReadAsStringAsync();
                        Recipe result = JsonConvert.DeserializeObject<Recipe>(json);
                        return result;
                    }
                    else
                    {
                        return new Recipe
                               {
                                   Title = "No data"
                               };
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
        }

        public async Task<List<Recipe>> GetAllRecipes()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback += (sender, certificate, chain, errors) => true;

            using (var client = new HttpClient(handler))
            {
                try
                {
                    HttpResponseMessage message = await client.GetAsync(baseUrl);

                    if (message.IsSuccessStatusCode)
                    {
                        string json = await message.Content.ReadAsStringAsync();
                        List<Recipe> result = JsonConvert.DeserializeObject<List<Recipe>>(json);
                        return result;
                    }
                    else
                    {
                        return new List<Recipe>
                               {
                                   new Recipe
                                   {
                                       Title = "No data"
                                   }
                               };
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
        }
    }
}