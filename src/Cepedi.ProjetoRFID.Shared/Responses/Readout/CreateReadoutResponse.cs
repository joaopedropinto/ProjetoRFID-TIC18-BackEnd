using Cepedi.ProjetoRFID.Domain.Entities;
namespace Cepedi.ProjetoRFID.Shared.Responses.Readout;

public class CreateReadoutResponse
{
    public Guid ReadoutId { get; }
    public DateTime ReadoutDate { get; }
    public List<Guid> ProductIds { get; } 

    public CreateReadoutResponse(Guid readoutId, DateTime readoutDate, List<Guid> productIds)
    {
        ReadoutId = readoutId;
        ReadoutDate = readoutDate;
        ProductIds = productIds;
    }
}
