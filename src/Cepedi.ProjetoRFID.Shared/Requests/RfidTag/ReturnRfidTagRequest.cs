using Cepedi.ProjetoRFID.Shared.Responses.RfidTag;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.RfidTag;

public class ReturnRfidTagRequest : IRequest<Result<ReturnRfidTagResponse>>, IValida
{
    public Guid Id { get; set; }
}
