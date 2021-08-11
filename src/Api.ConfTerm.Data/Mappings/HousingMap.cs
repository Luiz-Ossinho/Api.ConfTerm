using Api.ConfTerm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.ConfTerm.Data.Mappings
{
    public class HousingMap: IEntityTypeConfiguration<Housing>
    {
        public void Configure(EntityTypeBuilder<Housing> builder)
        {
            builder.ToTable("Housings");
            builder.HasKey(housing => housing.Id).HasName("housing_id");
            builder.Property(housing => housing.Identification).HasColumnName("identification");
            builder.HasOne(housing => housing.Owner).WithMany(user => user.Housings);

            //builder.HasOne(account => account.Customer).WithOne(customer => customer.Profile).HasForeignKey<Profile>();
        }
    }
}
