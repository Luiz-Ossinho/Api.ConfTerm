using Api.ConfTerm.Domain.Entities.Abstract;
using System;

namespace Api.ConfTerm.Domain.Entities
{
    public class Measurement : IdentifiableEntity
    {
        public AnimalProduction Production { get; set; }
        public float DryBulbTemperature { get; set; }
        public float WetBulbTemperature { get; set; }
        public float BlackGlobeTemperature { get; set; }
        public float DewPointTemperature { get; set; }
        public float Humidity { get; set; }
        public float TemperatureHumidityIndex { get; set; }
        public float BlackGlobeTemperatureHumidityIndex { get; set; }
        public DateTime Taken { get; set; }

    }
}
