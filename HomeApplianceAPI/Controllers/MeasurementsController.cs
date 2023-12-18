using Microsoft.AspNetCore.Mvc;

namespace HomeApplianceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeasurementsController : ControllerBase
    {
        private readonly ILogger<MeasurementsController> _logger;

        public MeasurementsController(ILogger<MeasurementsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetMeasurements(int offsetDays)
        {
            return Ok();
        }
    }
}