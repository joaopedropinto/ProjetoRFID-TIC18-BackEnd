using Cepedi.ProjetoRFID.Domain.Entities;
namespace Cepedi.ProjetoRFID.Shared.Responses.Readout;

public record ReturnReadoutResponse(Guid Id, DateTime ReadoutDate, List<Guid> Products);