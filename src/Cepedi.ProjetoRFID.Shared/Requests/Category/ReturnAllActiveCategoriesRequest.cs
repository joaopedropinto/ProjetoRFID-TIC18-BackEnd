using Cepedi.ProjetoRFID.Shared.Responses.Category;
using MediatR;
using OperationResult;


namespace Cepedi.ProjetoRFID.Shared.Requests.Category;

public class ReturnAllActiveCategoriesRequest : IRequest<Result<List<ReturnAllActiveCategoriesResponse>>>
{

}
