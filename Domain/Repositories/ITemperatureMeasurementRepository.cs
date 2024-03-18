using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Temperature
{
    public interface IMeasurementRepository : IRepositoryBase<TemperatureMeasurement>
    {
        Task<TemperatureMeasurement> GetLastMeasurementAsync();
    }
}
