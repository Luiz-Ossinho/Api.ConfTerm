using Api.ConfTerm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.ConfTerm.Data.Mappings
{
    public class MeasurementMap : IEntityTypeConfiguration<Measurement>
    {
        public void Configure(EntityTypeBuilder<Measurement> builder)
        {
            builder.ToTable("Medicao");
            builder.HasKey(measurement => measurement.Id);
            builder.Property(bgthi => bgthi.Id).HasColumnName("Medicao_id");
            builder.Property(measurement => measurement.TemperatureHumidityIndex).HasColumnName("ITU");
            builder.Property(measurement => measurement.BlackGlobeTemperatureHumidityIndex).HasColumnName("ITGU");
            builder.Property(measurement => measurement.BlackGlobeTemperature).HasColumnName("globo_negro_temperatura");
            builder.Property(measurement => measurement.DewPointTemperature).HasColumnName("ponto_orvalho");
            builder.Property(measurement => measurement.DryBulbTemperature).HasColumnName("bulbo_seco_temperatura");
            builder.Property(measurement => measurement.Humidity).HasColumnName("Umidade");
            builder.Property(measurement => measurement.WetBulbTemperature).HasColumnName("bulbo_umido_temperatura");
            builder.Property(measurement => measurement.Taken).HasColumnName("Tirada_em");
            builder.HasOne(measurement => measurement.Production).WithMany(production => production.Measurements);
        }
    }
}
