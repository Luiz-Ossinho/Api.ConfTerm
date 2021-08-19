using Api.ConfTerm.Domain.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.ConfTerm.Data.Mappings
{
    public abstract class ConfortMap<TConfort> : IEntityTypeConfiguration<TConfort> where TConfort : Confort
    {
        public virtual void Configure(EntityTypeBuilder<TConfort> builder)
        {
            builder.Property(confort => confort.MaximunAge).HasColumnName("idade_maxima");
            builder.Property(confort => confort.MinimunAge).HasColumnName("idade_minima");
            builder.OwnsOne(confort => confort.Level).Property(level => level.Id).HasColumnName("nivel_conforto");
        }
    }
}
