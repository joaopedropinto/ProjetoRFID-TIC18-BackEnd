namespace Cepedi.ProjetoRFID.Domain.Entities;

public class ReadoutEntity
{
    public Guid Id { get; set; }
    public DateTime ReadoutDate { get; set; }
    public List<Guid> Products { get; set; } = new List<Guid>();
    public ProductEntity? Product { get; set; }
}
