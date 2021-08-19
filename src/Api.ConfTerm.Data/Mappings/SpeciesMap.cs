using Api.ConfTerm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.ConfTerm.Data.Mappings
{
    public class SpeciesMap : IEntityTypeConfiguration<Species>
    {
        public void Configure(EntityTypeBuilder<Species> builder)
        {
            builder.ToTable("Especies");
            builder.Property(species => species.Name).HasColumnName("nome_especie");
            builder.HasMany(species => species.AnimalProductions).WithOne(animalProduction => animalProduction.Species);
        }
    }
}
