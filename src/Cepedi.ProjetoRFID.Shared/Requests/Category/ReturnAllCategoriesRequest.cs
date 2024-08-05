using Cepedi.ProjetoRFID.Shared.Responses.Category;
using MediatR;
using OperationResult;
using System.Collections.Generic;


namespace Cepedi.ProjetoRFID.Shared.Requests.Category;

public class ReturnAllCategoriesRequest : IRequest<Result<List<ReturnAllCategoriesResponse>>>
{

}
