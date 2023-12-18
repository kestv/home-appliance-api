using Domain.Models;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Temperature
{
    public interface ITemperatureMeasurementRepository : IRepositoryBase<TemperatureMeasurement>
    {
    }
}
