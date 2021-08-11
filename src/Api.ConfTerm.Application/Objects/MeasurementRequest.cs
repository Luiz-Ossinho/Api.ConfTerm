using Api.ConfTerm.Domain.Entities;
using System;

namespace Api.ConfTerm.Application.Objects
{
    public record MeasurementRequest(int AnimalProductionId, DateTime MeasurementDateTime, float TemperatureHumidityIndex, float BlackGlobeHumidityIndex,
        float DewPointTemperature, float DryBulbTemperature, float WetBulbTemperature, float Humidity, float BlackGlobeTemperature)
    {
        public Measurement ToMeasurement()
            => new()
            {
                BlackGlobeHumidityIndex = BlackGlobeHumidityIndex,
                BlackGlobeTemperature = BlackGlobeTemperature,
                DewPointTemperature = DewPointTemperature,
                DryBulbTemperature = DryBulbTemperature,
                Humidity = Humidity,
                TemperatureHumidityIndex = TemperatureHumidityIndex,
                WetBulbTemperature = WetBulbTemperature,
                Taken = MeasurementDateTime
            };
    }
}
