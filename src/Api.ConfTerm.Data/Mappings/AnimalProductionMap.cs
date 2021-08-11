using Api.ConfTerm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.ConfTerm.Data.Mappings
{
    public class AnimalProductionMap : IEntityTypeConfiguration<AnimalProduction>
    {
        public void Configure(EntityTypeBuilder<AnimalProduction> builder)
        {
            builder.ToTable("AnimalProductions");
            builder.HasKey(production => production.Id).HasName("AnimalProduction_id");
            builder.Property(production => production.Birthday).HasColumnName("birhday");
            builder.Property(production => production.Equipament).HasColumnName("equipament");
            builder.Property(production => production.MonitoringStart).HasColumnName("monitoring_start");
            builder.Property(production => production.MonitoringEnd).HasColumnName("monitoring_start");
            builder.HasOne(production => production.Housing).WithMany(housing => housing.AnimalProductions);
            //builder.HasOne(account => account.Customer).WithOne(customer => customer.Profile).HasForeignKey<Profile>();
        }
    }
}
