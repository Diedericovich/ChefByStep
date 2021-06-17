namespace ChefByStep.Services.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using ChefByStep.Models;

    using Newtonsoft.Json;

    public class UserRepository
    {
        // private const string baseUrl = "https://10.0.2.2:44350/api/User";
        private const string baseUrl = "https://chefbystepapimgmt.azure-api.net/api/api/User";

        public User CurrentlyLoggedInUser { get; set; } = new User();

        public async Task<User> GetUser(int id)
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
                        User result = JsonConvert.DeserializeObject<User>(json);
                        return result;
                    }
                    else
                    {
                        return new User
                               {
                                   Name = "No data"
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

        public async Task<List<User>> GetAllUsers()
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
                        List<User> result = JsonConvert.DeserializeObject<List<User>>(json);
                        return result;
                    }
                    else
                    {
                        return new List<User>
                               {
                                   new User
                                   {
                                       Name = "No data"
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