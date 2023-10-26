using Application.Models;

namespace Application.Contracts
{
    public interface IRentService
    {
        public Task<List<RentingData>> GetRentingData(int zip);
    }
}
