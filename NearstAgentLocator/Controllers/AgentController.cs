using Microsoft.AspNetCore.Mvc;
using NAL.Api.Domain;
using NAL.Api.Infrastructure.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NAL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IAgentService _agentService;
        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        [HttpGet("get-nearest-location")]
        public async Task<IActionResult> GetAgentLocation([FromQuery] double longitude, [FromQuery] double latitude, [FromQuery] long maxDistance = 5000, [FromQuery] long minDistance = 0)
        {
            try
            {
                var result = await _agentService.GetNearestLocationAsync(longitude, latitude, maxDistance, minDistance);
                return Ok(new { agentsNearby = result, message = "successful", agentsNearbyCount = result.Count });
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
