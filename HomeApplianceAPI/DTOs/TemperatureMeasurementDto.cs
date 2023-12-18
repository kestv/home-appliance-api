namespace HomeApplianceAPI.DTOs
{
    public class TemperatureMeasurementDto
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public long MeasuredOnUnixTime { get; set; }
    }
}
