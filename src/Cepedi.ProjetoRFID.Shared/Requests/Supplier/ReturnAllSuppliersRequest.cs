using Cepedi.ProjetoRFID.Shared.Responses.Supplier;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.Supplier;


public class ReturnAllSuppliersRequest : IRequest<Result<List<ReturnAllSuppliersResponse>>>, IValida
{

}
