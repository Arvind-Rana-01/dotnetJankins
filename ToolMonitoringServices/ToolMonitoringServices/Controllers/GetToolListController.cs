using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToolMonitoringServices.Services;

namespace ToolMonitoringServices.Controllers
{
        [ApiController]
        [Route("api/tool-monitoring/api/v1")]
       // [Authorize]
        public class GetToolListController : ControllerBase
        {
        private readonly IGetToolListService _joinService;
        private readonly ILogger<GetToolListController> _logger; // Logger instance

        public GetToolListController(IGetToolListService joinService, ILogger<GetToolListController> logger)
        {
            _joinService = joinService;
            _logger = logger; // Initialize the logger
        }

        [HttpGet("Tools")]
        public async Task<IActionResult> GetTools(string category=null, string search=null,string region=null)
        {
            try
            {
                _logger.LogInformation("GetTools called."); // Log information
                var result = await _joinService.GetTools(category, search, region);
                if (result != null)
                {
                    _logger.LogInformation($"GetTools completed successfully. Number of tools: {result.Count}"); // Log success
                    return Ok(result);
                }
                else
                {
                    _logger.LogWarning("GetTools returned null."); // Log warning
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in GetTools."); // Log error
                return BadRequest(ex);
            }
        }
    }
}
