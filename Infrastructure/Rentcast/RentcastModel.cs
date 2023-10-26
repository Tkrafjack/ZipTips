using Newtonsoft.Json;

namespace Infrastructure.Rentcast
{
    public record RentcastModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("zipCode")]
        public string ZipCode { get; set; } = string.Empty;

        [JsonProperty("rentalData")]
        public RentalHistoryModel RentalData { get; set; } = new RentalHistoryModel();
    }

    public record RentalHistoryModel
    {
        [JsonProperty("averageRent")]
        public int AverageRent { get; set; }

        [JsonProperty("minRent")]
        public int MinimumRent { get; set; }

        [JsonProperty("maxRent")]
        public int MaximumRent { get; set; }

        [JsonProperty("totalListings")]
        public int TotalListings { get; set; }

        [JsonProperty("dataByBedrooms")]
        public List<BedroomDataModel> RoomData { get; set; } = new List<BedroomDataModel>();

    }

    public record BedroomDataModel
    {
        [JsonProperty("bedrooms")]
        public int BedroomCount { get; set; }

        [JsonProperty("averageRent")]
        public int AverageRent { get; set; }

        [JsonProperty("minRent")]
        public int MinimumRent { get; set; }

        [JsonProperty("maxRent")]
        public int MaximumRent { get; set; }

        [JsonProperty("totalListings")]
        public int TotalListings { get; set; }
    }
}
