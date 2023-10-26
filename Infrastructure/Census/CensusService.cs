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
            //create client using censusBusinessMetrics data in program file
            var client = factory.CreateClient("censusBusinessMetrics");
            //adding path variables to url
            var url = client.BaseAddress + $"?get=ESTAB,EMPSZES&for=zipcode:{zip}&NAICS2017={sector}";

            //getting HTTP response from previously created request
            var response = await client.GetAsync(url);

            //throw if response code isnt successful
            if (response.IsSuccessStatusCode)
            {
                //get json data, serialize data to a string, then deserialize to List<List<string>>
                var responseString = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<List<List<string>>>(responseString);

                int establishments = 0;
                int employees = 0;

                //total establishments and employees
                // Skip the first row as it contains headers
                for (int i = 1; i < responseData.Count; i++)
                {
                    List<string> row = responseData[i];

                    establishments += int.Parse(row[0]);
                    employees += int.Parse(row[1]);

                }

                //model BusinessMetrics for return
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
                throw new Exception("Error getting bussines metrics from Census api");
            }

        }
    }
}
