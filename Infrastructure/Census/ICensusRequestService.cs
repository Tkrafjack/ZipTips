using API.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Census
{
    public interface ICensusRequestService
    {
        Task<List<BusinessMetrics>> GetBusinessMetrics(int zip, int businessSector);
    }
}
