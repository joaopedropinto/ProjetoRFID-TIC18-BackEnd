using Cepedi.ProjetoRFID.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.ProjetoRFID.Data.EntityTypeConfiguration;

public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.ToTable("Category");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Origin).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Color).IsRequired().HasMaxLength(100);

        builder.Property(e => e.IsDeleted).IsRequired().HasDefaultValue(false);

    }
}
