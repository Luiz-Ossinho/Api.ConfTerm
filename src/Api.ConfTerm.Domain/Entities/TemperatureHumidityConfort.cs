using Api.ConfTerm.Domain.Entities.Abstract;

namespace Api.ConfTerm.Domain.Entities
{
    public class TemperatureHumidityConfort : Confort
    {
        public float MinimunHumidity { get; set; }
        public float MaximunHumidity { get; set; }
        public float MinimunTemperature{ get; set; }
        public float MaximunTemperature { get; set; }
    }
}
