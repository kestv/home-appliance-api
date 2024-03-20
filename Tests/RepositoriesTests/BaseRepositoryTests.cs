using Domain.Entities;
using Domain.Temperature;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.RepositoriesTests
{
    public class BaseRepositoryTests : TestBase
    {
        private readonly IMeasurementRepository measurementRepository;
        public BaseRepositoryTests()
        {
            measurementRepository = new MeasurementRepository(Context);
        }

        [Fact]
        public async Task AddAsync_GetAsync_ReturnsAddedEntity()
        {
            int id = 99;
            await measurementRepository.AddAsync(new TemperatureMeasurement() { Id = id });
            var measurement = await measurementRepository.GetAsync(x => x.Id == id);
            Assert.NotNull(measurement);
            Assert.Equal(id, measurement!.Id);
        }


        [Fact]
        public async Task UpdateAsync_WithGivenTemperature_UpdatesEntityTemperature()
        {
            int id = 99;
            int temp = 20;
            var entity = new TemperatureMeasurement() { Id = id, Temperature = temp };
            var added = await measurementRepository.AddAsync(entity);
            Assert.Equal(temp, added.Temperature);

            int newTemp = 25;
            entity.Temperature = newTemp;
            await measurementRepository.UpdateAsync(entity);
            var measurement = await measurementRepository.GetAsync(x => x.Id == id);
            Assert.NotNull(measurement);
            Assert.Equal(id, measurement!.Id);
            Assert.Equal(newTemp, measurement!.Temperature);
        }


        [Fact]
        public async Task DeleteAsync_DeletesEntityFromContext()
        {
            int id = 99;
            var entity = new TemperatureMeasurement() { Id = id };
            await measurementRepository.AddAsync(entity);
            var measurement = await measurementRepository.GetAsync(x => x.Id == id);

            await measurementRepository.DeleteAsync(entity);
            measurement = await measurementRepository.GetAsync(x => x.Id == id);
            Assert.Null(measurement);
        }

        [Fact]
        public async Task ListAsync_AddedTwoEntities_ReturnsBothEntities()
        {
            await measurementRepository.AddAsync(new TemperatureMeasurement() { Id = 1 });
            await measurementRepository.AddAsync(new TemperatureMeasurement() { Id = 2 });

            var measurements = await measurementRepository.ListAsync(x => x.Id > 0);

            Assert.NotEmpty(measurements);
            Assert.Equal(2, measurements.Count);
        }
    }
}
