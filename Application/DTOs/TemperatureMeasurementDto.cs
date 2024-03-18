namespace Application.DTOs
{
    public record TemperatureMeasurementDto(double Temperature, double Humidity, DateTime MeasuredOn);
    public record CreateTemperatureMeasurementDto(double Temperature, double Humidity, long MeasuredOnUnixTime);
}
