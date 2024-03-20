using Application.DTOs;
using Application.Services;
using Domain.Entities;
using Domain.Temperature;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tests.ServiceTests
{
    public class MeasurementServiceTests : TestBase
    {
        [Fact]
        public async Task GetLastMeasurement_ReturnsDto()
        {
            int temp = 99;

            Mock<IMeasurementRepository> repo = new();
            repo.Setup(x => x.GetLastMeasurementAsync()).ReturnsAsync(new TemperatureMeasurement() { Temperature = temp });
            MeasurementService service = new(repo.Object, Mapper);

            var result = await service.GetLastMeasurementAsync();

            Assert.Equal(temp, result.Temperature);
        }

        [Fact]
        public async Task GetDailyMeasurements_NoData_ReturnsEmptyList()
        {
            Mock<IMeasurementRepository> repo = new();
            repo.Setup(x => x.ListAsync(x => x.Id < 0)).ReturnsAsync(new List<TemperatureMeasurement>());
            MeasurementService service = new(repo.Object, Mapper);

            var result = await service.GetDailyMeasurementsAsync(0);

            Assert.Empty(result);
        }

        [Fact]
        public async Task GetDailyMeasurements_OneData_ReturnsOneElementInList()
        {
            Mock<IMeasurementRepository> repo = new();
            repo.Setup(x => x.ListAsync(It.IsAny<Expression<Func<TemperatureMeasurement, bool>>>()))
                .ReturnsAsync(new List<TemperatureMeasurement>() { new() });
            MeasurementService service = new(repo.Object, Mapper);

            var result = await service.GetDailyMeasurementsAsync(0);

            Assert.NotEmpty(result);
            Assert.Single(result);
        }

        [Fact]
        public async Task GetDailyMeasurements_MoreThanOneData_ReturnsListOfElements()
        {
            Mock<IMeasurementRepository> repo = new();
            repo.Setup(x => x.ListAsync(It.IsAny<Expression<Func<TemperatureMeasurement, bool>>>()))
                .ReturnsAsync(new List<TemperatureMeasurement>() { 
                    new(),
                    new(),
                    new()
                });
            MeasurementService service = new(repo.Object, Mapper);

            var result = await service.GetDailyMeasurementsAsync(0);

            Assert.NotEmpty(result);
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task AddMeasurement_CallsAddAsync()
        {
            Mock<IMeasurementRepository> repo = new();
            repo.Setup(x => x.AddAsync(It.IsAny<TemperatureMeasurement>())).ReturnsAsync(new TemperatureMeasurement());
            MeasurementService service = new(repo.Object, Mapper);

            await service.CreateMeasurementAsync(new CreateTemperatureMeasurementDto(0,0,0));

            repo.Verify(x => x.AddAsync(It.IsAny<TemperatureMeasurement>()));
        }
    }
}
