using Application.DTOs;

namespace Application.Services
{
    public interface IMeasurementService
    {
        Task CreateMeasurementAsync(CreateTemperatureMeasurementDto dto);
        Task<IEnumerable<TemperatureMeasurementDto>> GetDailyMeasurementsAsync(int dayOffset);
        Task<TemperatureMeasurementDto> GetLastMeasurementAsync();
    }
}