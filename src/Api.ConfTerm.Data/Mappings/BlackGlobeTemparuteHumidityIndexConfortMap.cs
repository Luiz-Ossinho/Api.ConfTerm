using Api.ConfTerm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.ConfTerm.Data.Mappings
{
    public class BlackGlobeTemparuteHumidityIndexConfortMap : ConfortMap<BlackGlobeTemparuteHumidityIndexConfort>
    {
        public override void Configure(EntityTypeBuilder<BlackGlobeTemparuteHumidityIndexConfort> builder)
        {
            base.Configure(builder);
            builder.ToTable("BlackGlobeTemparuteHumidityIndexConforts");
            builder.Property(bgthi => bgthi.MinimunBlackGlobeTemperatureHumidityIndex).HasColumnType("itgu_minimo");
            builder.Property(bgthi => bgthi.MaximunBlackGlobeTemperatureHumidityIndex).HasColumnType("itgu_maximo");
            builder.HasOne(bgthi => bgthi.Species).WithMany(species => species.BlackGlobeTemparuteHumidityIndexConforts);
        }
    }
}
