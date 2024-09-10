using Cepedi.ProjetoRFID.Shared.Responses.Supplier;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.Supplier;


public class ReturnSupplierRequest : IRequest<Result<ReturnSupplierResponse>>, IValida
{
    public Guid Id { get; set; }
}
