using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.ASP.Data
{
    using System.Net.Http;
    using System.Net.Http.Json;

    using ChefByStep.ASP.Models;

    using Newtonsoft.Json;

    public class RecipeRatingRepo : IRecipeRatingRepo
    {
        private const string apiUrl = "https://localhost:44350";

        private string url;

        public async Task<RecipeRating> GetRecipeRatingAsync(int id)
        {
            url = GenerateUrl(id);
            HttpResponseMessage message = await GetHttpResponseMessageAsync(url);
            RecipeRating result = await GetEntityFromJsonAsync(message);

            return result;
        }

        public async Task<IList<RecipeRating>> GetRecipeRatingsAsync()
        {
            url = $"{apiUrl}/api/RecipeRating";
            HttpResponseMessage message = await GetHttpResponseMessageAsync(url);
            IList<RecipeRating> result = await GetEntitiesFromJsonAsync(message);

            return result;
        }

        public async Task PostRecipeRatingAsync(RecipeRating recipeRating)
        {
            url = $"{apiUrl}/api/RecipeRating";
            var client = new HttpClient();
            HttpResponseMessage message = await client.PostAsJsonAsync<RecipeRating>(url, recipeRating);
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

        private async Task<RecipeRating> GetEntityFromJsonAsync(HttpResponseMessage message)
        {
            string json = await message.Content.ReadAsStringAsync();

            try
            {
                RecipeRating result = JsonConvert.DeserializeObject<RecipeRating>(json);
                return result;
            }
            catch (Exception e)
            {
                throw new JsonSerializationException("Serialization failed", e);
            }
        }

        private async Task<List<RecipeRating>> GetEntitiesFromJsonAsync(HttpResponseMessage message)
        {
            string json = await message.Content.ReadAsStringAsync();

            try
            {
                return JsonConvert.DeserializeObject<List<RecipeRating>>(json);
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

            return $"{apiUrl}/api/RecipeRating/{id}";
        }
    }
}