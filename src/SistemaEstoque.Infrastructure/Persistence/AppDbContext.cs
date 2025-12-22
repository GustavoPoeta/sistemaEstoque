using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Domain.Entities;

namespace SistemaEstoque.Infrastructure.Persistence;

public sealed class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {  }
    public DbSet<User> Users => Set<User>();
    public DbSet<AdminKey> AdminKeys => Set<AdminKey>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AppDbContext).Assembly
        );
    }
}


