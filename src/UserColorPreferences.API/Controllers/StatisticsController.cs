using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserColorPreferences.API.Services.Interfaces;

namespace UserColorPreferences.API.Controllers
{
    [ApiController]
    [Route("statistics")]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        // GET: api/statistics
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _statisticsService.Get();

            return Ok(users);
        }
    }
}
