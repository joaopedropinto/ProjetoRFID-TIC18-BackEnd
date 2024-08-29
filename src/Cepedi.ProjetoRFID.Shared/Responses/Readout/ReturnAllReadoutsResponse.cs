//using Cepedi.ProjetoRFID.Domain.Entities;
namespace Cepedi.ProjetoRFID.Shared.Responses.Readout;

public record ReturnAllReadoutsResponse(Guid Id, DateTime ReadoutDate, List<string> Tags);