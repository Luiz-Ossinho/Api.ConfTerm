using Api.ConfTerm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.ConfTerm.Data.Mappings
{
    public class MeasurementMap : IEntityTypeConfiguration<Measurement>
    {
        public void Configure(EntityTypeBuilder<Measurement> builder)
        {
            builder.ToTable("Measurements");
            builder.HasKey(measurement => measurement.Id).HasName("measurement_id");
            builder.Property(measurement => measurement.TemperatureHumidityIndex).HasColumnName("TemperatureHumidityIndex");
            builder.Property(measurement => measurement.BlackGlobeTemperatureHumidityIndex).HasColumnName("BlackGlobeHumidityIndex");
            builder.Property(measurement => measurement.BlackGlobeTemperature).HasColumnName("BlackGlobeTemperature");
            builder.Property(measurement => measurement.DewPointTemperature).HasColumnName("DewPointTemperature");
            builder.Property(measurement => measurement.DryBulbTemperature).HasColumnName("DryBulbTemperature");
            builder.Property(measurement => measurement.Humidity).HasColumnName("Humidity");
            builder.Property(measurement => measurement.WetBulbTemperature).HasColumnName("WetBulbTemperature");
            builder.Property(measurement => measurement.Taken).HasColumnName("Taken");
            builder.HasOne(measurement => measurement.AnimalProduction).WithMany(production => production.Measurements);
        }
    }
}
