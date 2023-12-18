using Domain.Models;
using Domain.Temperature;

namespace Infrastructure.Repositories
{
    public class TemperatureMeasurementRepository : RepositoryBase<TemperatureMeasurement>, ITemperatureMeasurementRepository
    {
    }
}
