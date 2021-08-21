using Api.ConfTerm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.ConfTerm.Data.Mappings
{
    public class SpeciesMap : IEntityTypeConfiguration<Species>
    {
        public void Configure(EntityTypeBuilder<Species> builder)
        {
            builder.ToTable("Especie");
            builder.HasKey(species => species.Id);
            builder.Property(bgthi => bgthi.Id).HasColumnName("especie_id");    
            builder.Property(species => species.Name).HasColumnName("nome");
            builder.HasMany(species => species.AnimalProductions).WithOne(animalProduction => animalProduction.Species);
        }
    }
}
