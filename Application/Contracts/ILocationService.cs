using API.Models;

namespace Application.Contracts
{
    public interface ILocationService
    {
        public Task<LocationData> GetStateAndCity(int zip);
    }
}
