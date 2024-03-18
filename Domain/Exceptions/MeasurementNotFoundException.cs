using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class MeasurementNotFoundException : Exception
    {
        public MeasurementNotFoundException() : base("Measurement was not found.")
        {
        }

        public MeasurementNotFoundException(string message) : base(message)
        {
        }

        public MeasurementNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
