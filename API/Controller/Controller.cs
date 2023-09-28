using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ZipController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetZipCodeInformation()
        {
            return Ok("This is the base route for ZipController.");
        }
    }
}
