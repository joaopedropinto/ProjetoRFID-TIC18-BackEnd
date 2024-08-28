using Cepedi.ProjetoRFID.Shared.Responses.Product;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.Product;

public class GetProductsByRfidsRequest : IRequest<Result<CombinedProductResponse>>
{
    public List<string> Rfids { get; set; }

    public GetProductsByRfidsRequest(List<string> rfids)
    {
        Rfids = rfids;
    }
}
