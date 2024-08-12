using Cepedi.ProjetoRFID.Shared.Responses.RfidTag;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.RfidTag;

public class CreateRfidTagRequest : IRequest<Result<CreateRfidTagResponse>>, IValida
{
    public required string RfidTag { get; set; }
}
