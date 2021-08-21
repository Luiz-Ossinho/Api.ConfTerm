using Api.ConfTerm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.ConfTerm.Data.Mappings
{
    public class HousingMap: IEntityTypeConfiguration<Housing>
    {
        public void Configure(EntityTypeBuilder<Housing> builder)
        {
            builder.ToTable("Alojamento");
            builder.HasKey(housing => housing.Id);
            builder.Property(bgthi => bgthi.Id).HasColumnName("Alojamento_id");
            builder.Property(housing => housing.Identification).HasColumnName("Indentificao");
            builder.HasOne(housing => housing.Owner).WithMany(user => user.Housings);
        }
    }
}
