using Domain.Models;
using Domain.Temperature;
using HomeApplianceAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HomeApplianceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeasurementsController : ControllerBase
    {
        private readonly ILogger<MeasurementsController> _logger;
        private readonly ITemperatureMeasurementRepository _temperatureMeasurementRepository;

        public MeasurementsController(ILogger<MeasurementsController> logger, ITemperatureMeasurementRepository temperatureMeasurementRepository)
        {
            _logger = logger;
            _temperatureMeasurementRepository = temperatureMeasurementRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMeasurements(int offsetDays)
        {
            var result = await _temperatureMeasurementRepository.ListAsync(x => x.MeasuredOn >= DateTime.Now.AddDays(-offsetDays));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddMeasurement(TemperatureMeasurementDto dto)
        {
            DateTime dateTime = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(dto.MeasuredOnUnixTime).ToLocalTime();

            TemperatureMeasurement measurement = new() { Humidity = dto.Humidity, Temperature = dto.Temperature, MeasuredOn = dateTime };

            var added = await _temperatureMeasurementRepository.AddAsync(measurement);
            return Ok(added);
        }
    }
}