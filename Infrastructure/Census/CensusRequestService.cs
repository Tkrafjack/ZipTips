using API.Models.Responses;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Census
{
    public class CensusRequestService : ICensusRequestService
    {
        private readonly IHttpClientFactory factory;

        public async Task<List<BusinessMetrics>> GetBusinessMetrics(int zip, int businessSector)
        {
            var client = factory.CreateClient();

            // Specify the base address without the query parameters
            client.BaseAddress = new Uri("https://api.census.gov/data/2018/zbp");

            // Construct the query parameters using a QueryString
            var queryParams = new Dictionary<string, string>
            {
                { "get", "ESTAB,EMPSZES" },
                { "for", $"zipcode:{zip}" }, // Specify the ZIP code and "*" to get all results for that ZIP code
                { "NAICS2017", $"{businessSector}" }
            };

            // Create a UriBuilder to build the complete URL with query string
            var uriBuilder = new UriBuilder(client.BaseAddress)
            {
                Query = string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={kvp.Value}"))
            };

            try
            {
                // Send the HTTP request with the complete URL
                var response = await client.GetFromJsonAsync<List<BusinessMetrics>>(uriBuilder.Uri.ToString());

                if (response != null)
                {
                    return response;
                }
                else
                {
                    //Handle this more gracefully
                    return new List<BusinessMetrics>();
                }
            }
            catch (Exception)
            {
                throw new Exception("Error getting bussines metrics from Census api");
            }
        }
    }
}
