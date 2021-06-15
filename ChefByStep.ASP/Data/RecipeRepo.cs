using ChefByStep.ASP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChefByStep.ASP.Data
{

    public class RecipeRepo : IRecipeRepo
    {
        private const string apiUrl = "https://localhost:44350";
        private string url;

        public async Task<Recipe> GetRecipeAsync(int id)
        {
            url = GenerateUrl(id);
            HttpResponseMessage message = await GetHttpResponseMessageAsync(url);
            Recipe result = await GetEntityFromJsonAsync(message);

            return result;
        }

        public async Task<IList<Recipe>> GetRecipesAsync()
        {
            url = $"{ apiUrl}/api/Recipe";
            HttpResponseMessage message = await GetHttpResponseMessageAsync(url);
            IList<Recipe> result = await GetEntitiesFromJsonAsync(message);

            return result;
        }

        private async Task<HttpResponseMessage> GetHttpResponseMessageAsync(string url)
        {
            var client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync(url);

            if (!message.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Request failed: {message.StatusCode}");
            }

            return message;

        }

        private async Task<Recipe> GetEntityFromJsonAsync(HttpResponseMessage message)
        {
            string json = await message.Content.ReadAsStringAsync();

            try
            {
                Recipe result = JsonConvert.DeserializeObject<Recipe>(json);
                return result;
            }
            catch (Exception e)
            {
                throw new JsonSerializationException("Serialization failed", e);
            }

        }

        private async Task<List<Recipe>> GetEntitiesFromJsonAsync(HttpResponseMessage message)
        {
            string json = await message.Content.ReadAsStringAsync();

            try
            {
                return JsonConvert.DeserializeObject<List<Recipe>>(json);

            }
            catch (Exception e)
            {
                throw new JsonSerializationException("Serialization failed", e);
            }

        }

        private string GenerateUrl(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return $"{apiUrl}/api/Recipe/{id}";
        }

    }
}
