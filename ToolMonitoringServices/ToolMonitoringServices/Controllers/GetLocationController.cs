using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToolMonitoringServices.Services;
using Microsoft.SqlServer.Server;

namespace ToolMonitoringServices.Controllers
{
    [ApiController]
    [Route("api/tool-monitoring/api/v1")]
    //[Authorize]
    public class GetLocationController : Controller
    {
        private readonly IGetLocationService _joinService;
        private readonly ILogger<GetLocationController> _logger;

        public GetLocationController(IGetLocationService joinService, ILogger<GetLocationController> logger)
        {
            _joinService = joinService;
            _logger = logger;
        }
        [HttpGet("Location")]
        public async Task<IActionResult> GetLocations()
        {
            try
            {
                var result = await _joinService.GetLocations();


                _logger.LogInformation("GetCategory method executed successfully.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing GetCategory.");
                return BadRequest(ex);
            }
        }


    }
}
