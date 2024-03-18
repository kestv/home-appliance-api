using Domain.Entities;
using Domain.Exceptions;
using Domain.Temperature;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MeasurementRepository : RepositoryBase<TemperatureMeasurement>, IMeasurementRepository
    {
        public MeasurementRepository(HomeApplianceContext context) : base(context)
        {
        }

        public async Task<TemperatureMeasurement> GetLastMeasurementAsync()
        {
            var measurement = await Context.Set<TemperatureMeasurement>().OrderByDescending(x => x.MeasuredOn).FirstOrDefaultAsync();
            if (measurement is null)
            {
                throw new MeasurementNotFoundException();
            }
            return measurement;
        }
    }
}
