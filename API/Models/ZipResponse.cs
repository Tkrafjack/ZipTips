using Application.Models;

namespace API.Models
{
    public class ZipResponse
    {
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int TotalEstablishments { get; set; } 
        public int TotalEmployees { get; set; }
        public int ZipCode { get; set; }
        public int BusinessSector { get; set; }
        public List<RentingData> RentalData { get; set; } = new List<RentingData>();

    }
}
