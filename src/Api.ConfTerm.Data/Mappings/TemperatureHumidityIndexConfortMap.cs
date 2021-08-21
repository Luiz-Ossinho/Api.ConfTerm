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
            builder.ToTable("Conforto_Itu");
            builder.HasKey(thi => thi.Id);
            builder.Property(bgthi => bgthi.Id).HasColumnName("conforto_itu_id");
            builder.Property(thi => thi.MinimunTemperatureHumidityIndex).HasColumnType("itu_minimo");
            builder.Property(thi => thi.MaximunTemperatureHumidityIndex).HasColumnType("itu_maximo");
            builder.HasOne(thi => thi.Species).WithMany(species => species.TemperatureHumidityIndexConforts);
        }
    }
}
