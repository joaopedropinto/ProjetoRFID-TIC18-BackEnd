using Cepedi.ProjetoRFID.Shared.Responses.Packaging;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.Packaging
{
    public class ReturnAllActivePackagesRequest : IRequest<Result<List<ReturnPackagingResponse>>>
    {
    }
}
