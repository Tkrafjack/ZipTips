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
            //create client using zippopotamus data in program file
            var client = factory.CreateClient("zippopotamus");
            //adding passed zipcode as path variable to url
            var url = client.BaseAddress + $"{zip}";

            //getting HTTP response from previously created request
            var response = await client.GetAsync(url);

            //throw if response code isnt successful
            if (response.IsSuccessStatusCode)
            {
                //get json data, serialize data to a string, then deserialize to LocationData
                var responseString = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<LocationData>(responseString);

                return responseData;
            }
            else
            {
                throw new Exception($"{response.StatusCode}: Error getting state from Zippopotamus api");
            }
        }
    }
}
