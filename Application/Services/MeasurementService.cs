using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Temperature;
namespace Application.Services
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IMapper _mapper;
        private readonly IMeasurementRepository _temperatureMeasurementRepository;

        public MeasurementService(IMeasurementRepository temperatureMeasurementRepository, IMapper mapper)
        {
            _temperatureMeasurementRepository = temperatureMeasurementRepository;
            _mapper = mapper;
        }

        public async Task<TemperatureMeasurementDto> GetLastMeasurementAsync()
        {
            return _mapper.Map<TemperatureMeasurementDto>(await _temperatureMeasurementRepository.GetLastMeasurementAsync());
        }

        public async Task<IEnumerable<TemperatureMeasurementDto>> GetDailyMeasurementsAsync(int dayOffset)
        {
            var result = await _temperatureMeasurementRepository.ListAsync(x => x.MeasuredOn >= DateTime.Now.AddDays(-dayOffset));
            return _mapper.Map<List<TemperatureMeasurementDto>>(result);

        }

        public async Task CreateMeasurementAsync(CreateTemperatureMeasurementDto dto)
        {
            DateTime dateTime = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(dto.MeasuredOnUnixTime).ToLocalTime();

            var entity = _mapper.Map<TemperatureMeasurement>(dto);
            entity.MeasuredOn = dateTime;

            await _temperatureMeasurementRepository.AddAsync(entity);
        }
    }
}
