using API.Models;
using Application.Contracts;
using Newtonsoft.Json;

namespace Infrastructure.Census
{
    public class CensusService : ICensusService
    {
        private readonly IHttpClientFactory factory;

        public CensusService(IHttpClientFactory factory)
        {
            this.factory = factory;
        }

        public async Task<BusinessMetrics> GetBusinessMetrics(int zip, int sector)
        {
            var client = factory.CreateClient("censusBusinessMetrics");
            var url = client.BaseAddress + $"?get=ESTAB,EMPSZES&for=zipcode:{zip}&NAICS2017={sector}";

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<List<List<string>>>(responseString);

                int establishments = 0;
                int employees = 0;

                // Skip the first row as it contains headers
                for (int i = 1; i < responseData.Count; i++)
                {
                    List<string> row = responseData[i];

                    establishments += int.Parse(row[0]);
                    employees += int.Parse(row[1]);

                }

                BusinessMetrics businessMetrics = new()
                {
                    TotalEstablishments = establishments,
                    TotalEmployees = employees,
                    ZipCode = zip,
                    BusinessSector = sector
                };

                return businessMetrics;
            }
            else
            {
                //TODO: make exception for getting error codes from census
                throw new Exception("Error getting bussines metrics from Census api");
            }

        }
    }
}
