using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TemperatureMeasurement, TemperatureMeasurementDto>();
            CreateMap<CreateTemperatureMeasurementDto, TemperatureMeasurement>();
        }
    }
}
