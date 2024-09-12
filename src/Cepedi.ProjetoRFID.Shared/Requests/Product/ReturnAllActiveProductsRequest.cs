using Cepedi.ProjetoRFID.Shared.Responses.Product;
using MediatR;
using OperationResult;
using System.Collections.Generic;


namespace Cepedi.ProjetoRFID.Shared.Requests.Product;

public class ReturnAllActiveProductsRequest : IRequest<Result<List<ReturnAllActiveProductsResponse>>>
{

}
