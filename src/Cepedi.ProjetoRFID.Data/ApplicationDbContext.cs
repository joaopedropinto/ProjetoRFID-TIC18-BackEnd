using System.Diagnostics.CodeAnalysis;
using Cepedi.ProjetoRFID.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Cepedi.ProjetoRFID.Domain;

namespace Cepedi.ProjetoRFID.Data;

[ExcludeFromCodeCoverage]
public class ApplicationDbContext : DbContext
{
    public DbSet<CategoryEntity> Category { get; set; } = default!;
    public DbSet<ProductEntity> Product { get; set; } = default!;
    public DbSet<SupplierEntity> Supplier { get; set; } = default!;
    public DbSet<RfidTagEntity> RfidTag { get; set; } = default!;
    public DbSet<ReadoutEntity> Readout { get; set; } = default!;
    public DbSet<PackagingEntity> Packaging { get; set; } = default!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
