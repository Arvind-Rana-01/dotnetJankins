using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToolMonitoringServices.Model;
using ToolMonitoringServices.Services;

namespace ToolMonitoringService.Controllers
{
    [ApiController]
    [Route("api/tool-monitoring/api/v1")]
    //[Authorize]

    public class GetCategoriesController : ControllerBase
    {
        private readonly IGetCategoriesService _joinService;
        private readonly ILogger<GetCategoriesController> _logger;
        public GetCategoriesController(IGetCategoriesService joinService, ILogger<GetCategoriesController> logger)
        {
            _joinService = joinService;
            _logger = logger;
        }

        [HttpGet("Category")]
        public async Task<IActionResult> GetCategory()
        {
            try
            {
                var result = await _joinService.GetCategory();


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

