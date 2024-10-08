using Cepedi.ProjetoRFID.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.ProjetoRFID.Data.EntityTypeConfiguration
{
    public class PackagingEntityTypeConfiguration : IEntityTypeConfiguration<PackagingEntity>
    {
        public void Configure(EntityTypeBuilder<PackagingEntity> builder)
        {
            builder.ToTable("Packaging");
            builder.HasKey(packaging => packaging.Id);
            builder.Property(packaging => packaging.Name).IsRequired().HasMaxLength(100);
            builder.Property(packaging => packaging.IsActive).IsRequired();
        }
    }
}
