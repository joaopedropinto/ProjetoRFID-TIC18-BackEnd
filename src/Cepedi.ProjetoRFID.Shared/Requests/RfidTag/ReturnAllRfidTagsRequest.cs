using Cepedi.ProjetoRFID.Shared.Responses.RfidTag;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.RfidTag;

public class ReturnAllRfidTagsRequest : IRequest<Result<List<ReturnAllRfidTagsResponse>>>, IValida
{

}
