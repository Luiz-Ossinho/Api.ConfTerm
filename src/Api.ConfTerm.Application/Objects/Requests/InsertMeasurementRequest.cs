using Api.ConfTerm.Application.Objects.Abstract;
using Api.ConfTerm.Domain.Entities;
using System;

namespace Api.ConfTerm.Application.Objects.Requests
{
    public record InsertMeasurementRequest(
        int AnimalProductionId,
        DateTime MeasurementDateTime,
        float TemperatureHumidityIndex,
        float BlackGlobeHumidityIndex,
        float DewPointTemperature,
        float DryBulbTemperature,
        float WetBulbTemperature,
        float Humidity,
        float BlackGlobeTemperature
    ) : IApplicationRequest
    {
        public Measurement ToMeasurement()
            => new()
            {
                BlackGlobeTemperatureHumidityIndex = BlackGlobeHumidityIndex,
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
