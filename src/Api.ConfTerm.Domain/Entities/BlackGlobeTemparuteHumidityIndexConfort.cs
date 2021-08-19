using Api.ConfTerm.Domain.Entities.Abstract;

namespace Api.ConfTerm.Domain.Entities
{
    public class BlackGlobeTemparuteHumidityIndexConfort : Confort
    {
        public float MinimunBlackGlobeTemperatureHumidityIndex { get; set; }
        public float MaximunBlackGlobeTemperatureHumidityIndex { get; set; }
    }
}
