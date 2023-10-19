using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class RentingData
    {
        [JsonProperty("zipCode")]
        public int ZipCode { get; set; }
        [JsonProperty("rentalData")]
        public List<BedroomData> RentalData { get; set; }
    }

    public class BedroomData
    {
        [JsonProperty("bedrooms")]
        public int BedroomCount { get; set; }
        [JsonProperty("averageRent")]
        public int AverageRent { get; set; }
        [JsonProperty("minRent")]
        public int LowestRent { get; set; }
        [JsonProperty("maxRent")]
        public int HighestRent { get; set; }
    }
}
