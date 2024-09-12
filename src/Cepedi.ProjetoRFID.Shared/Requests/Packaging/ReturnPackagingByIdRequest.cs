using Cepedi.ProjetoRFID.Shared.Responses.Packaging;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.Packaging
{
    public class ReturnPackagingByIdRequest : IRequest<Result<ReturnPackagingResponse>>
    {
        public Guid PackagingId { get; set; }
    }
}
