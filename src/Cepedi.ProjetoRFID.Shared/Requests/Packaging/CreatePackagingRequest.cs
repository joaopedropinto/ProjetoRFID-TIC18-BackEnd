using Cepedi.ProjetoRFID.Shared.Responses.Packaging;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.Packaging
{
    public class CreatePackagingRequest : IRequest<Result<CreatePackagingResponse>>, IValida
    {
        public required string Name { get; set; }
    }
}
