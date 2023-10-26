using Application;
using Application.Contracts;
using Application.Models;
using Newtonsoft.Json;

namespace Infrastructure.Rentcast
{
    public class RentcastService : IRentService
    {
        public readonly IHttpClientFactory factory;

        public RentcastService(IHttpClientFactory factory)
        {
            this.factory = factory;
        }

        public async Task<List<RentingData>> GetRentingData(int zip)
        {
            //create client using rentcast data in program file
            var client = factory.CreateClient("rentcast");
            //adding passed zipcode as path variable to url
            var url = client.BaseAddress + $"zipCode={zip}";

            //gets secret rentcast api key
            //HARDCODE API KEY HERE IF SECRET FILE DOESNT EXIST
            //https://developers.rentcast.io/reference/authentication#creating-an-api-key
            string apiKey = Secrets.rentcastApiKey;

            //creating HTTP request with header variable apiKey
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
                {
                    { "accept", "application/json" },
                    { "X-Api-Key", apiKey },
                },
            };

            //getting HTTP response from previously created request
            var response = await client.SendAsync(request);

            //throw if response code isnt successful
            if (response.IsSuccessStatusCode)
            {
                //get json data, serialize data to a string, then deserialize to RentcastModel
                var responseString = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<RentcastModel>(responseString);

                //convert RentcastModel to return type List<RentingData>
                return ConvertRentcastModel(responseData);
            }
            else
            {
                throw new Exception($"{response.StatusCode}: Error getting renting data from Rentcast api");
            }
        }

        //Converts RentcastModel to List<RentingData>
        private List<RentingData> ConvertRentcastModel(RentcastModel data)
        {
            var rentingData = new List<RentingData>();
            
            foreach (var rentalType in data.RentalData.RoomData)
            {
                rentingData.Add( new RentingData() 
                    {
                        BedroomCount = rentalType.BedroomCount,
                        AverageRent = rentalType.AverageRent,
                        LowestRent = rentalType.MinimumRent,
                        HighestRent = rentalType.MaximumRent
                    });
            }

            return rentingData;
        }
    }
}
