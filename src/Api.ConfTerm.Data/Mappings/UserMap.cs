using Api.ConfTerm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.ConfTerm.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).HasColumnName("usuario_id");
            builder.Property(user => user.Name).HasColumnName("nome");
            builder.Property(user => user.Password).HasColumnName("senha");
            builder.Property(user => user.Salt).HasColumnName("salt_senha");
            builder.OwnsOne(user=> user.Email).Property(email=>email.Value).HasColumnName("email");
            builder.OwnsOne(user => user.Type).Property(type=> type.Id).HasColumnName("tipo");
        }
    }
}
