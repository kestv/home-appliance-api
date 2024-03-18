using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HomeApplianceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeasurementsController : ControllerBase
    {
        private readonly IMeasurementService _measurementService;

        public MeasurementsController(IMeasurementService measurementService)
        {
            _measurementService = measurementService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDailyMeasurements(int offsetDays)
        {
            var result = await _measurementService.GetDailyMeasurementsAsync(offsetDays);
            return Ok(result);
        }

        [HttpGet("last")]
        public async Task<IActionResult> GetLastMeasurement()
        {
            var result = await _measurementService.GetLastMeasurementAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddMeasurement(CreateTemperatureMeasurementDto dto)
        {
            await _measurementService.CreateMeasurementAsync(dto);
            return Ok();
        }
    }
}