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
            builder.ToTable("Conforto_ITGU");
            builder.HasKey(bgthi => bgthi.Id);
            builder.Property(bgthi => bgthi.Id).HasColumnName("Conforto_ITGU_id");
            builder.Property(bgthi => bgthi.MinimunBlackGlobeTemperatureHumidityIndex).HasColumnName("itgu_minimo");
            builder.Property(bgthi => bgthi.MaximunBlackGlobeTemperatureHumidityIndex).HasColumnName("itgu_maximo");
            builder.HasOne(bgthi => bgthi.Species).WithMany(species => species.BlackGlobeTemparuteHumidityIndexConforts);
        }
    }
}
