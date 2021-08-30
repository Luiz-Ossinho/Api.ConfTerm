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
            builder.ToTable("Conforto_Temperatura_Umidade");
            builder.HasKey(th => th.Id);
            builder.Property(bgthi => bgthi.Id).HasColumnName("Conforto_Temperatura_Umidade_id");
            builder.Property(th => th.MinimunHumidity).HasColumnName("umidade_minima");
            builder.Property(th => th.MaximunHumidity).HasColumnName("umidade_maxima");
            builder.Property(th => th.MinimunTemperature).HasColumnName("temperatura_minima");
            builder.Property(th => th.MaximunTemperature).HasColumnName("temperatura_maxima");
            builder.HasOne(th => th.Species).WithMany(species => species.TemperatureHumidityConforts);
        }
    }
}
