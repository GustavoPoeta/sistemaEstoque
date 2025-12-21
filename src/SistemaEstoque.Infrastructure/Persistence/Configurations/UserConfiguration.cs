using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Infrastructure.Persistence.Configurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Table
        builder.ToTable("usuarios");

        // Primary key
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        // Name
        builder.Property(u => u.Name)
            .HasColumnName("nome")
            .HasMaxLength(100)
            .IsRequired();

        // Email (Value Object)
        builder.OwnsOne(u => u.Email, email =>
        {
            email.Property(e => e.Value)
                .HasColumnName("email")
                .HasMaxLength(150)
                .IsRequired();
        });

        // Access level
        builder.Property(u => u.AccessLevel)
            .HasColumnName("nivel_acesso")
            .HasMaxLength(50)
            .IsRequired();

        // Password
        builder.Property(u => u.Password)
            .HasColumnName("senha")
            .HasMaxLength(255)
            .IsRequired();
    }
}
