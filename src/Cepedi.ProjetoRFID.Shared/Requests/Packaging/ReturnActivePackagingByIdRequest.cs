using Cepedi.ProjetoRFID.Shared.Responses.Packaging;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.Packaging
{
    public class ReturnActivePackagingByIdRequest : IRequest<Result<ReturnPackagingResponse>>
    {
        public Guid PackagingId { get; set; }
    }
}
