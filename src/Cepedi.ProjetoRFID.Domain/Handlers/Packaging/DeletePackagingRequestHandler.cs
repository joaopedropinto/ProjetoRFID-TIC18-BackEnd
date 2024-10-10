using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Enums;
using Cepedi.ProjetoRFID.Shared.Exceptions;
using Cepedi.ProjetoRFID.Shared.Requests.Packaging;
using Cepedi.ProjetoRFID.Shared.Responses.Packaging;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Packaging
{
    public class DeletePackagingRequestHandler : IRequestHandler<DeletePackagingRequest, Result<DeletePackagingResponse>>
    {
        private readonly IPackagingRepository _packagingRepository;
        private readonly ILogger<DeletePackagingRequestHandler> _logger;

        public DeletePackagingRequestHandler(IPackagingRepository packagingRepository, ILogger<DeletePackagingRequestHandler> logger)
        {
            _packagingRepository = packagingRepository;
            _logger = logger;
        }

        public async Task<Result<DeletePackagingResponse>> Handle(DeletePackagingRequest request, CancellationToken cancellationToken)
        {
            var packaging = await _packagingRepository.ReturnActivePackagingByIdAsync(request.PackagingId);

            if (packaging == null)
            {
                return Result.Error<DeletePackagingResponse>(new ExceptionApplication(RegisteredErrors.IdPackagingInvalid));
            }

            await _packagingRepository.DeletePackagingAsync(request.PackagingId);

            return Result.Success(new DeletePackagingResponse(packaging.Id, packaging.Name, packaging.IsDeleted));
        }
    }
}
