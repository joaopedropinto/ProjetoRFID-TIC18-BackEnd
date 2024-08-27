using Cepedi.ProjetoRFID.Shared.Responses.Supplier;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.Supplier;


public class DeleteSupplierRequest : IRequest<Result<DeleteSupplierResponse>>, IValida
{
    public Guid Id { get; set; }
}