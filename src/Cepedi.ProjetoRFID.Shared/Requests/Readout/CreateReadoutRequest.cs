//using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Shared.Responses.Readout;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.Readout;

public class CreateReadoutRequest : IRequest<Result<CreateReadoutResponse>>, IValida
{
    public required DateTime ReadoutDate { get; set; }
    public required List<string> Tags { get; set; }
}
