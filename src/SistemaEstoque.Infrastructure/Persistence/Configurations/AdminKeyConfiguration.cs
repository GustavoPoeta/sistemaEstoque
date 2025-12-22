using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Infrastructure.Persistence.Configurations;

public sealed class AdminKeyConfiguration
    : IEntityTypeConfiguration<AdminKey>
{
    public void Configure(EntityTypeBuilder<AdminKey> builder)
    {
        builder.ToTable("chave_administrador");

        builder.HasKey(k => k.Id);

        builder.Property(k => k.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(k => k.UserId)
            .HasColumnName("id_usuario")
            .IsRequired();

        builder.Property(k => k.Key)
            .HasColumnName("chave")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(k => k.Active)
            .HasColumnName("ativa")
            .IsRequired();
    }
}