using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.Packaging
{
    public class ReturnPackagingByIdRequest : IRequest<Result<ReturnPackagingByIdRequest>>
    {
        public Guid PackagingId { get; set; }
    }
}
