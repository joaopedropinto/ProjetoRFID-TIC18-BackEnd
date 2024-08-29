namespace Cepedi.ProjetoRFID.Domain.Entities;

public class ReadoutEntity
{
    public Guid Id { get; set; }
    public DateTime ReadoutDate { get; set; }
    public List<string> Tags { get; set; } = new List<string>();
    //public ProductEntity? Product { get; set; }
}
