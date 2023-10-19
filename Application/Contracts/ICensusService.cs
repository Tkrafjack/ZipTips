using API.Models;

namespace Application.Contracts
{
    public interface ICensusService
    {
        Task<BusinessMetrics> GetBusinessMetrics(int zip, int businessSector);
    }
}
