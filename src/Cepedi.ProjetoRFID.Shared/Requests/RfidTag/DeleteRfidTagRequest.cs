using Cepedi.ProjetoRFID.Shared.Responses.RfidTag;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.RfidTag;

public class DeleteRfidTagRequest : IRequest<Result<DeleteRfidTagResponse>>, IValida
{
    public int Id { get; set; }
}
