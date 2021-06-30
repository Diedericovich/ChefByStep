using ChefByStep.ASP.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ChefByStep.ASP.Data
{
    public class UserRepo : IUserRepo
    {
        private const string apiUrl = "https://localhost:44350";

        //private const string apiUrl = "https://chefbystepapimgmt.azure-api.net/api/api/User";
        private string url;

        public async Task<ApiUser> GetUserAsync(int id)
        {
            url = GenerateUrl(id);
            HttpResponseMessage message = await GetHttpResponseMessageAsync(url);
            ApiUser result = await GetEntityFromJsonAsync(message);

            return result;
        }

        public async Task<ApiUser> GetUserByNameAsync(string name)
        {
            url = GenerateUrl(name);
            HttpResponseMessage message = await GetHttpResponseMessageAsync(url);
            ApiUser result = await GetEntityFromJsonAsync(message);

            return result;
        }

        public async Task<IList<ApiUser>> GetUsersAsync()
        {
            url = $"{ apiUrl}/api/User";
            HttpResponseMessage message = await GetHttpResponseMessageAsync(url);
            IList<ApiUser> result = await GetEntitiesFromJsonAsync(message);

            return result;
        }

        public async Task PostUserAsync(ApiUser user)
        {
            url = $"{ apiUrl}/api/User";
            var client = new HttpClient();
            HttpResponseMessage message = await client.PostAsJsonAsync<ApiUser>(url, user);
        }

        public async Task UpdateUserAsync(ApiUser user)
        {
            url = $"{ apiUrl}/api/User";
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(user);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage message = await client.PutAsync(url, httpContent);

            if (!message.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Request failed: {message.StatusCode}");
            }
        }

        public async Task AddFavouriteRecipe(FavouriteDto favourite)
        {
            url = $"{ apiUrl}/api/User/AddFavourite";
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(favourite);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage message = await client.PostAsync(url, httpContent);

            if (!message.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Request failed: {message.StatusCode}");
            }
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

        private async Task<ApiUser> GetEntityFromJsonAsync(HttpResponseMessage message)
        {
            string json = await message.Content.ReadAsStringAsync();

            try
            {
                ApiUser result = JsonConvert.DeserializeObject<ApiUser>(json);
                return result;
            }
            catch (Exception e)
            {
                throw new JsonSerializationException("Serialization failed", e);
            }
        }

        private async Task<List<ApiUser>> GetEntitiesFromJsonAsync(HttpResponseMessage message)
        {
            string json = await message.Content.ReadAsStringAsync();

            try
            {
                return JsonConvert.DeserializeObject<List<ApiUser>>(json);
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

            return $"{apiUrl}/api/User/{id}";
        }

        private string GenerateUrl(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            return $"{apiUrl}/api/User/{name}";
        }
    }
}