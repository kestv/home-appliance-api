using Application.DTOs;
using Application.Services;
using Domain.Exceptions;
using Domain.Temperature;
using HomeApplianceAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.ControllerTests
{
    public class MeasurementsControllerTests
    {
        [Fact]
        public async Task GetDailyMeasurements_ReturnsOkResponse()
        {
            Mock<IMeasurementService> service = new();
            service.Setup(x => x.GetDailyMeasurementsAsync(It.IsAny<int>())).ReturnsAsync(new List<TemperatureMeasurementDto>());
            MeasurementsController controller = new(service.Object);

            var result = await controller.GetDailyMeasurements(0);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetLastMeasurement_ReturnsOkResponse()
        {
            Mock<IMeasurementService> service = new();
            service.Setup(x => x.GetLastMeasurementAsync()).ReturnsAsync(new TemperatureMeasurementDto(0, 0, DateTime.Now));
            MeasurementsController controller = new(service.Object);

            var result = await controller.GetLastMeasurement();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetLastMeasurement_ReturnsNull_ThrowsMeasurementNotFoundEx()
        {
            Mock<IMeasurementRepository> repo = new();
            repo.Setup(x => x.GetLastMeasurementAsync()).Throws<MeasurementNotFoundException>();
            IMeasurementService service = new MeasurementService(repo.Object, null!);
            MeasurementsController controller = new(service);

            await Assert.ThrowsAsync<MeasurementNotFoundException>(async () => await controller.GetLastMeasurement());
        }

        [Fact]
        public async Task AddMeasurement_ReturnsOkResponse()
        {
            CreateTemperatureMeasurementDto dto = new(0, 0, 0);
            Mock<IMeasurementService> service = new();
            service.Setup(x => x.CreateMeasurementAsync(It.IsAny<CreateTemperatureMeasurementDto>())).Returns(Task.CompletedTask);
            MeasurementsController controller = new(service.Object);

            var result = await controller.AddMeasurement(dto);
            Assert.IsType<OkResult>(result);
        }
    }
}
