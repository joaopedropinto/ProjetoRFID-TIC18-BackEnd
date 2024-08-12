namespace Cepedi.ProjetoRFID.Domain;

public class RfidTagEntity
{
    public int Id { get; set; }
    public string RfidTag { get; set; }

    internal void Update(string rfidTag)
    {
        RfidTag = rfidTag;
    }
}
