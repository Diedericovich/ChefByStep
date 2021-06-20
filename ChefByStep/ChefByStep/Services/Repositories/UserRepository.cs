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
         private const string BaseUrl = "https://10.0.2.2:44350/api/User";
        //private const string BaseUrl = "https://chefbystepapimgmt.azure-api.net/api/api/User";

 
        public async Task<User> GetUser(int id)
        {
            var url = $"{BaseUrl}/{id}";
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
                        return new User { Name = "No data" };
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
                    HttpResponseMessage message = await client.GetAsync(BaseUrl);

                    if (message.IsSuccessStatusCode)
                    {
                        string json = await message.Content.ReadAsStringAsync();
                        List<User> result = JsonConvert.DeserializeObject<List<User>>(json);
                        return result;
                    }
                    else
                    {
                        return new List<User> { new User { Name = "No data" } };
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
        }

        public async Task<User> FindUserByFirstName(string name)
        {
            var ListOfUsers = await GetAllUsers();
            User user = new User();
            foreach (var item in ListOfUsers)
            {
                if (item.Name == name)
                {
                    user = item;
                }
                else
                {
                    Console.WriteLine("User not found");
                }
            }
            return user;
        }


    }
}