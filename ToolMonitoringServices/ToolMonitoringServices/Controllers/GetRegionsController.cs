using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToolMonitoringServices.Services;
using Microsoft.SqlServer.Server;

namespace ToolMonitoringServices.Controllers
{
    [ApiController]
    [Route("api/tool-monitoring/api/v1")]
    //[Authorize]

    public class GetRegionsController : ControllerBase
    {
        private readonly IGetRegionsService _joinService;
        private readonly ILogger<GetRegionsController> _logger;

        public GetRegionsController(IGetRegionsService joinService, ILogger<GetRegionsController> logger)
        {
            _joinService = joinService;
            _logger = logger;
        }

        [HttpGet("Regions")]
        public async Task<IActionResult> GetRegion()
        {
            try
            {

                _logger.LogInformation("Starting to get regions");
            
                var result = await _joinService.GetRegion();
                _logger.LogInformation($"Regions obtained: {result.Count}");
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error while getting regions");
                return BadRequest(ex);
            }
        }
    }
}
