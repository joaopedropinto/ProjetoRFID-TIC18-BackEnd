//using Cepedi.ProjetoRFID.Domain.Entities;
namespace Cepedi.ProjetoRFID.Shared.Responses.Readout;

public class CreateReadoutResponse
{
    public Guid ReadoutId { get; }
    public DateTime ReadoutDate { get; }
    public List<string> TagIds { get; } 

    public CreateReadoutResponse(Guid readoutId, DateTime readoutDate, List<string> tagIds)
    {
        ReadoutId = readoutId;
        ReadoutDate = readoutDate;
        TagIds = tagIds;
    }
}
