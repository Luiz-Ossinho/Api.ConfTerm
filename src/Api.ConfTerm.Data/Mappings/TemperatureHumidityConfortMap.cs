using Api.ConfTerm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.ConfTerm.Data.Mappings
{
    public class TemperatureHumidityConfortMap : ConfortMap<TemperatureHumidityConfort>
    {
        public override void Configure(EntityTypeBuilder<TemperatureHumidityConfort> builder)
        {
            base.Configure(builder);
            builder.ToTable("BlackGlobeTemparuteHumidityIndexConforts");
            builder.Property(bgthi => bgthi.MinimunHumidity).HasColumnType("umidade_minima");
            builder.Property(bgthi => bgthi.MaximunHumidity).HasColumnType("umidade_maxima");
            builder.Property(bgthi => bgthi.MinimunTemperature).HasColumnType("temperatura_minima");
            builder.Property(bgthi => bgthi.MaximunTemperature).HasColumnType("temperatura_maxima");
            builder.HasOne(bgthi => bgthi.Species).WithMany(species => species.TemperatureHumidityConforts);
        }
    }
}
