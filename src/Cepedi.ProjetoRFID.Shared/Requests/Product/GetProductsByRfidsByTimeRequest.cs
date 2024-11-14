using Cepedi.ProjetoRFID.Shared.Responses.Product;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.Product;

public class GetProductsByRfidsByTimeRequest : IRequest<Result<CombinedProductResponse>>
{
    public int ReadingTime { get; set; }
}
