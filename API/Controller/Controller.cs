using API.Models;
using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("[controller]")]

    [ApiController]
    public class ZipController : ControllerBase
    {
        private readonly ICensusService censusService;
        private readonly ILocationService zippopotamusService;

        public ZipController(ICensusService censusService, ILocationService zippopotamusService)
        {
            this.censusService = censusService;
            this.zippopotamusService = zippopotamusService;
        }

        [HttpGet]
        public async Task<IActionResult> GetZipCodeInformation(int zip = 34108, int businessSector = 72)
        {
            BusinessMetrics businessMetricsResult;
            LocationData zippopotamusResponse;

            try
            {
                businessMetricsResult = await censusService.GetBusinessMetrics(zip, businessSector);
                zippopotamusResponse = await zippopotamusService.GetStateAndCity(zip);
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
                City = zippopotamusResponse.Places[0].City
            };
            return Ok(response);
        }
    }
}
