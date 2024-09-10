using Cepedi.ProjetoRFID.Shared.Responses.Packaging;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.Packaging
{
    public class DeletePackagingRequest : IRequest<Result<DeletePackagingResponse>>
    {
        public Guid PackagingId { get; set; }
    }
}
