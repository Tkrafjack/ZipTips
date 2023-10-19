using API.Models;
using Application.Contracts;
using Newtonsoft.Json;

namespace Infrastructure.Services.Zippopotamus
{
    public class ZippopotamusService : ILocationService
    {
        private readonly IHttpClientFactory factory;

        public ZippopotamusService(IHttpClientFactory factory)
        {
            this.factory = factory;
        }

        public async Task<LocationData> GetStateAndCity(int zip) 
        {
            var client = factory.CreateClient("zippopotamus");
            var url = client.BaseAddress + $"{zip}";

            var jsonResponse = await client.GetAsync(url);

            if (jsonResponse.IsSuccessStatusCode)
            {
                var responseString = await jsonResponse.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<LocationData>(responseString);

                return response;
            }
            else
            {
                throw new Exception($"{jsonResponse.StatusCode}: Error getting state from Zippopotamus api");
            }
        }
    }
}
