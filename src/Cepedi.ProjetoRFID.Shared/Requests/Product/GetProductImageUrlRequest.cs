using Cepedi.ProjetoRFID.Shared.Responses.Product;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.Product
{
	public class GetProductImageUrlRequest : IRequest<Result<GetProductImageUrlResponse>>
	{
        public string? ObjectName { get; set; }
    }
}
