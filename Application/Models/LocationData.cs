using Newtonsoft.Json;

namespace API.Models
{
    public class LocationData
    {
        [JsonProperty("post code")]
        public string ZipCode { get; set; }

        [JsonProperty("places")]
        public List<PlacesModel> Places { get; set; }
    }

    public class PlacesModel
    {
        [JsonProperty("place name")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }
    }
}
