using Domain.Entities;
using Domain.Exceptions;
using Domain.Temperature;
using Infrastructure.Repositories;

namespace Tests
{
    public class MeasurementRepositoryTests : TestBase
    {
        private readonly IMeasurementRepository measurementRepository;
        public MeasurementRepositoryTests()
        {
            measurementRepository = new MeasurementRepository(Context);
        }

        [Fact]
        public async Task GetLastMeasurement_NoMeasurements_ThrowsMeasurementNotFoundException()
        {
            await Assert.ThrowsAsync<MeasurementNotFoundException>(() => measurementRepository.GetLastMeasurementAsync());
        }
    
        [Fact]
        public async Task GetLastMeasuremet_MeasurementAdded_ReturnsMeasurement()
        {
            Context.Add(new TemperatureMeasurement() { Humidity = 1, Id = 1, MeasuredOn = DateTime.Now, Temperature = 1 });
            await Context.SaveChangesAsync();

            var measurement = await measurementRepository.GetLastMeasurementAsync();
            Assert.Equal(1, measurement.Id);
        }

        [Fact]
        public async Task GetLastMeasurement_TwoMeasurementsAdded_ReturnsLastMeasurement()
        {
            int id = 2;
            Context.Add(new TemperatureMeasurement() { Humidity = 1, Id = 1, MeasuredOn = DateTime.Now, Temperature = 1 });
            await Context.SaveChangesAsync();

            Context.Add(new TemperatureMeasurement() { Humidity = 1, Id = id, MeasuredOn = DateTime.Now, Temperature = 1 });
            await Context.SaveChangesAsync();

            var measurement = await measurementRepository.GetLastMeasurementAsync();
            Assert.Equal(id, measurement.Id);
        }

        
    }
}