using Api.ConfTerm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.ConfTerm.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(user => user.Id).HasName("user_id");
            builder.Property(user => user.Password).HasColumnName("hash");
            builder.Property(user => user.Salt).HasColumnName("hash_salt");
            builder.OwnsOne(user=> user.Email).Property(email=>email.Value).HasColumnName("email");
            builder.OwnsOne(user => user.Type).Property(type=> type.Id).HasColumnName("type");
        }
    }
}
