using Cepedi.ProjetoRFID.Shared.Responses.Supplier;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.Supplier;


public class CreateSupplierRequest : IRequest<Result<CreateSupplierResponse>>, IValida
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string PhoneNumber { get; set; }
}
