using Cepedi.ProjetoRFID.Shared.Responses.Readout;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.Readout;

public class ReturnReadoutRequest : IRequest<Result<ReturnReadoutResponse>>, IValida
{
    public Guid Id { get; set; }
}
