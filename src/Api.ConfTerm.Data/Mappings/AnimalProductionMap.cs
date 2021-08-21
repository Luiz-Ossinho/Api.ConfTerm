using Api.ConfTerm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.ConfTerm.Data.Mappings
{
    public class AnimalProductionMap : IEntityTypeConfiguration<AnimalProduction>
    {
        public void Configure(EntityTypeBuilder<AnimalProduction> builder)
        {
            builder.ToTable("Producao_Animal");
            builder.HasKey(production => production.Id);
            builder.Property(bgthi => bgthi.Id).HasColumnName("ProducaoAnimal_id");
            builder.Property(production => production.Birthday).HasColumnName("nascimento");
            builder.Property(production => production.Equipament).HasColumnName("equipamento");
            builder.Property(production => production.MonitoringStart).HasColumnName("inicio_monitoramento");
            builder.Property(production => production.MonitoringEnd).HasColumnName("fim_monitoramento");
            builder.HasOne(production => production.Housing).WithMany(housing => housing.AnimalProductions);
        }
    }
}
