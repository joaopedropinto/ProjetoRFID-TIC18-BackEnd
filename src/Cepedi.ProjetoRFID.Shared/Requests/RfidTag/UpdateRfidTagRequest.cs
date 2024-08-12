using Cepedi.ProjetoRFID.Shared.Responses.RfidTag;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.RfidTag;

public class UpdateRfidTagRequest : IRequest<Result<UpdateRfidTagResponse>>, IValida
{
    public int Id { get; set; }
    public string? RfidTag { get; set; }
}
