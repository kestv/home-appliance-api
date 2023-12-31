﻿using Domain.Entities;

namespace Domain.Models
{
    public class TemperatureMeasurement : BaseEntity
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public DateTime MeasuredOn { get; set; }
    }
}
