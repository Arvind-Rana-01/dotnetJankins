using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToolMonitoringServices.Services;

namespace ToolMonitoringServices.Controllers
{
    [ApiController]
    [Route("tool-monitoring/api/v1")]
    //[Authorize]
    public class GetToolCategoryCountController : ControllerBase
    {
        private readonly IGetToolCategoryCountService _joinService;
        private readonly ILogger<GetToolCategoryCountController> _logger; // Logger instance

        public GetToolCategoryCountController(IGetToolCategoryCountService joinService, ILogger<GetToolCategoryCountController> logger)
        {
            _joinService = joinService;
            _logger = logger; // Initialize the logger
        }

        [HttpGet("ToolCategory")]
        public async Task<IActionResult> GetToolCategory()
        {
            try
            {
                _logger.LogInformation("GetToolCategory called."); // Log information
                var result = await _joinService.GetToolCategory();
                if (result != null)
                {
                    _logger.LogInformation($"GetToolCategory completed successfully. Number of categories: {result.Count}"); // Log success
                    return Ok(result);
                }
                else
                {
                    _logger.LogWarning("GetToolCategory returned null."); // Log warning
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in GetToolCategory."); // Log error
                return BadRequest(ex.Message);
            }
        }
    }
}
