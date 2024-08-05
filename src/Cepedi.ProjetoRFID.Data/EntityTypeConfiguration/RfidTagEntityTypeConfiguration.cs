using Cepedi.ProjetoRFID.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cepedi.ProjetoRFID.Data;

public class RfidTagEntityTypeConfiguration : IEntityTypeConfiguration<RfidTagEntity>
{
    public void Configure(EntityTypeBuilder<RfidTagEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Rfid).IsRequired();
    }

}
