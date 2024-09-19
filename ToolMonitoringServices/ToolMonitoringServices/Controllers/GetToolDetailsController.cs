using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToolMonitoringServices.Services;

namespace ToolMonitoringServices.Controllers
{
    [ApiController]
    [Route("tool-monitoring/api/v1")]
    //[Authorize]
    public class GetToolDetailsController : ControllerBase
    {
        private readonly IGetToolDetailsService _joinService;
        private readonly ILogger<GetToolDetailsController> _logger; // Logger instance

        public GetToolDetailsController(IGetToolDetailsService joinService, ILogger<GetToolDetailsController> logger)
        {
            _joinService = joinService;
            _logger = logger; // Initialize the logger
        }


        [HttpGet("ToolDetail")]
        public async Task<IActionResult> GetToolCategory()
        {
            try
            {
                _logger.LogInformation("GetToolDetail called."); // Log information
                var result = await _joinService.GetToolDetail();
                if (result != null)
                {
                    _logger.LogInformation($"GetToolDetail completed successfully. Number of details: {result.Count}"); // Log success
                    return Ok(result);
                }
                else
                {
                    _logger.LogWarning("GetToolDetail returned null."); // Log warning
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in GetToolDetail."); // Log error
                return BadRequest(ex.Message);
            }
        }
    }
}
