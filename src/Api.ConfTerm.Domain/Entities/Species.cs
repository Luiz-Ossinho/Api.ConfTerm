using Api.ConfTerm.Domain.Entities.Abstract;
using System.Collections.Generic;

namespace Api.ConfTerm.Domain.Entities
{
    public class Species : IdentifiableEntity
    {
        public string Name { get; set; }
        public ICollection<AnimalProduction> AnimalProductions { get; set; } = new List<AnimalProduction>();
        public ICollection<BlackGlobeTemparuteHumidityIndexConfort> BlackGlobeTemparuteHumidityIndexConforts { get; set; } = new List<BlackGlobeTemparuteHumidityIndexConfort>();
        public ICollection<TemperatureHumidityConfort> TemperatureHumidityConforts { get; set; } = new List<TemperatureHumidityConfort>();
        public ICollection<TemperatureHumidityIndexConfort> TemperatureHumidityIndexConforts { get; set; } = new List<TemperatureHumidityIndexConfort>();
    }
}
