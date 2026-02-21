using Microsoft.AspNetCore.Mvc;
namespace _51_Logs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ILogger<LogsController> _logger;

        public LogsController(ILogger<LogsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Get()
        {
            _logger.LogInformation("Get fetched at {time}", DateTime.Now);
            return Ok();
        }
    }
}
