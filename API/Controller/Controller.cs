using API.Models;
using Application.Contracts;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("[controller]")]

    [ApiController]
    public class ZipController : ControllerBase
    {
        private readonly ICensusService censusService;
        private readonly ILocationService zippopotamusService;
        private readonly IRentService rentService;

        public ZipController(ICensusService censusService, ILocationService zippopotamusService, IRentService rentService)
        {
            this.censusService = censusService;
            this.zippopotamusService = zippopotamusService;
            this.rentService = rentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetZipCodeInformation(int zip = 34108, int businessSector = 72)
        {
            BusinessMetrics businessMetricsResult;
            LocationData zippopotamusResponse;
            List<RentingData> rentcastResponse;

            try
            {
                businessMetricsResult = await censusService.GetBusinessMetrics(zip, businessSector);
                zippopotamusResponse = await zippopotamusService.GetStateAndCity(zip);
                rentcastResponse = await rentService.GetRentingData(zip);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            ZipResponse response = new()
            {
                TotalEstablishments = businessMetricsResult.TotalEstablishments,
                TotalEmployees = businessMetricsResult.TotalEmployees,
                ZipCode = businessMetricsResult.ZipCode,
                BusinessSector = businessMetricsResult.BusinessSector,
                State = zippopotamusResponse.Places[0].State,
                City = zippopotamusResponse.Places[0].City,
                RentalData = rentcastResponse
            };
            return Ok(response);
        }
    }
}
