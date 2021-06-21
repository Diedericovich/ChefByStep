namespace ChefByStep.Services.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    public class GenericRepository<T>
    {
        private const string baseUrl = "https://chefbystepapimgmt.azure-api.net/api/api/";

        public async Task<IEnumerable<T>> GetAll()
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
                        List<T> result = JsonConvert.DeserializeObject<List<T>>(json);
                        return result;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
        }

        public async Task<object> GetById(object id)
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
                        T result = JsonConvert.DeserializeObject<T>(json);
                        return result;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
        }

        public void Insert(T obj)
        {
        }

        public void Update(T obj)
        {
        }

        public void Delete(object id)
        {
        }

        public void Save()
        {
        }
    }
}