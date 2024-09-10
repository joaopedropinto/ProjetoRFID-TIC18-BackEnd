using Cepedi.ProjetoRFID.Shared.Responses.Product;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.Product;

public class DeleteProductRequest : IRequest<Result<DeleteProductResponse>>, IValida
{
    public Guid Id { get; set; }
}
