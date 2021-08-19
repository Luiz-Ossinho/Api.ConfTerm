using Api.ConfTerm.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Api.ConfTerm.Data.Extensions
{
    public static class EntityTypeConfigurationExentensions
    {
        public static ModelBuilder ApplyMappingConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new AnimalProductionMap());
            modelBuilder.ApplyConfiguration(new HousingMap());
            modelBuilder.ApplyConfiguration(new MeasurementMap());

            modelBuilder.ApplyConfiguration(new SpeciesMap());
            modelBuilder.ApplyConfiguration(new BlackGlobeTemparuteHumidityIndexConfortMap());
            modelBuilder.ApplyConfiguration(new TemperatureHumidityConfortMap());
            modelBuilder.ApplyConfiguration(new TemperatureHumidityIndexConfortMap());

            return modelBuilder;
        }
    }
}
