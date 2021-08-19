using Api.ConfTerm.Domain.Entities.Abstract;

namespace Api.ConfTerm.Domain.Entities
{
    public class TemperatureHumidityIndexConfort : Confort
    {
        public float MinimunTemperatureHumidityIndex { get; set; }
        public float MaximunTemperatureHumidityIndex { get; set; }
    }
}
