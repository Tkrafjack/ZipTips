using Application.Contracts;

namespace Infrastructure.Rentcast
{
    public class RentcastService : IRentService
    {
        public readonly IHttpClientFactory factory;

        public RentcastService(IHttpClientFactory factory)
        {
            this.factory = factory;
        }

        //public async Task<RentingData> GetRentingData(int zip) 
        //{
        //    var client = factory.CreateClient("rentcast");
        //    string url = client.BaseAddress + $"zipCode={zip}";

        //    //TODO dont hardcode key
        //    string apiKey = "f04ea0d3a689426aa51520c8f5478bc3";

        //    var request = new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Get,
        //        RequestUri = new Uri(url),
        //        Headers =
        //        {
        //            { "accept", "application/json" },
        //            { "X-Api-Key", apiKey },
        //        },
        //    };

        //    using (var response = await client.SendAsync(request))
        //    {
        //        response.EnsureSuccessStatusCode();
        //        var body = await response.Content.ReadAsStringAsync();
        //    }
        //}
    }
}
