using Cepedi.ProjetoRFID.Shared.Responses.Product;
using MediatR;
using OperationResult;
using System.Collections.Generic;


namespace Cepedi.ProjetoRFID.Shared.Requests.Product;

public class ReturnAllProductsRequest : IRequest<Result<List<ReturnAllProductsResponse>>>
{

}
