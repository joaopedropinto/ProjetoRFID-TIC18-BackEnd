using Cepedi.ProjetoRFID.Shared.Responses.Category;
using MediatR;
using OperationResult;


namespace Cepedi.ProjetoRFID.Shared.Requests.Category;

public class ReturnAllCategoriesRequest : IRequest<Result<List<ReturnAllCategoriesResponse>>>
{

}
