using Cepedi.ProjetoRFID.Shared.Responses.Packaging;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.Packaging
{
    public class UpdatePackagingRequest : IRequest<Result<UpdatePackagingResponse>>, IValida
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
