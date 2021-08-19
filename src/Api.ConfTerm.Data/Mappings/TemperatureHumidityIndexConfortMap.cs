using Api.ConfTerm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.ConfTerm.Data.Mappings
{
    public class TemperatureHumidityIndexConfortMap : ConfortMap<TemperatureHumidityIndexConfort>
    {
        public override void Configure(EntityTypeBuilder<TemperatureHumidityIndexConfort> builder)
        {
            base.Configure(builder);
            builder.ToTable("BlackGlobeTemparuteHumidityIndexConforts");
            builder.Property(bgthi => bgthi.MinimunTemperatureHumidityIndex).HasColumnType("itu_minimo");
            builder.Property(bgthi => bgthi.MaximunTemperatureHumidityIndex).HasColumnType("itu_maximo");
            builder.HasOne(bgthi => bgthi.Species).WithMany(species => species.TemperatureHumidityIndexConforts);
        }
    }
}
