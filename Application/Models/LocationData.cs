using Newtonsoft.Json;

namespace API.Models
{
    public class LocationData
    {
        [JsonProperty("post code")]
        public string ZipCode { get; set; } = string.Empty;

        [JsonProperty("places")]
        public List<PlacesModel> Places { get; set; } = new List<PlacesModel>();
    }

    public class PlacesModel
    {
        [JsonProperty("place name")]
        public string City { get; set; } = string.Empty;

        [JsonProperty("state")]
        public string State { get; set; } = string.Empty;

        [JsonProperty("longitude")]
        public string Longitude { get; set; } = string.Empty;

        [JsonProperty("latitude")]
        public string Latitude { get; set; } = string.Empty;
    }
}
