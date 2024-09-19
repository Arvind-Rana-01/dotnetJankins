using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToolMonitoringServices.DataAccess.Interface;
using ToolMonitoringServices.Services;

namespace ToolMonitoringServices.Controllers
{
        [ApiController]
        [Route("api/tool-monitoring/api/v1")]
       // [Authorize]
        public class GetToolHierarchyController : ControllerBase
        {
        private readonly IGetToolHierarchyService _joinService;
        private readonly ILogger<GetToolHierarchyController> _logger; // Logger instance

        public GetToolHierarchyController(IGetToolHierarchyService joinService, ILogger<GetToolHierarchyController> logger)
        {
            _joinService = joinService;
            _logger = logger; // Initialize the logger
        }
        //public async Task<IActionResult> GetHierarchy(string toolId)
        [HttpGet("ToolsHierarchy")]
        public async Task<IActionResult> GetHierarchy(string toolId)
        {
            try
            {
                _logger.LogInformation("GetHierarchy called."); // Log information
                var result = await _joinService.GetHierarchy(toolId);
                if (result != null)
                {
                    _logger.LogInformation($"GetHierarchy completed successfully. Number of items: {result.Count}"); // Log success
                    return Ok(result);
                }
                else
                {
                    _logger.LogWarning("GetHierarchy returned null."); // Log warning
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred in GetHierarchy."); // Log error
                return BadRequest(ex);
            }
        }
    }
    }
