using Cepedi.ProjetoRFID.Shared.Responses.Product;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.Product;

public class ReturnProductRequest : IRequest<Result<ReturnProductResponse>>, IValida
{
    public int Id { get; set; }
}
