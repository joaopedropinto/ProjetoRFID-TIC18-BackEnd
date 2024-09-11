using Cepedi.ProjetoRFID.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.ProjetoRFID.Data.EntityTypeConfiguration;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<ProductEntity>
{
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
                builder.ToTable("Product");
                builder.HasKey(e => e.Id);
                builder.Property(e => e.IdCategory).IsRequired();
                builder.Property(e => e.IdSupplier).IsRequired();
                builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
                builder.Property(e => e.RfidTag).IsRequired();
                builder.Property(e => e.Description).IsRequired().HasMaxLength(100);
                builder.Property(e => e.Weight).IsRequired().HasColumnType("decimal(18,2)");
                builder.Property(e => e.ManufacDate).IsRequired();
                builder.Property(e => e.DueDate).IsRequired();
                builder.Property(e => e.UnitMeasurement).IsRequired().HasMaxLength(20);
                builder.Property(e => e.PackingType).IsRequired().HasMaxLength(100);
                builder.Property(e => e.BatchNumber).IsRequired().HasMaxLength(100);
                builder.Property(e => e.Quantity).IsRequired();
                builder.Property(e => e.Price).IsRequired().HasColumnType("decimal(18,2)");
                builder.Property(e => e.Height).IsRequired().HasColumnType("decimal(18,2)");
                builder.Property(e => e.Width).IsRequired().HasColumnType("decimal(18,2)");
                builder.Property(e => e.Length).IsRequired().HasColumnType("decimal(18,2)");
                builder.Property(e => e.Volume).IsRequired().HasColumnType("decimal(18,2)");
                builder.Property(e => e.IdReadout).IsRequired();
                builder.Property(e => e.Active).IsRequired().HasDefaultValue(true);

                builder.HasOne(e => e.Category)
                        .WithMany()
                        .HasForeignKey(e => e.IdCategory)
                        .IsRequired();

                builder.HasOne(e => e.Supplier)
                        .WithMany()
                        .HasForeignKey(e => e.IdSupplier)
                        .IsRequired();
        }
}
