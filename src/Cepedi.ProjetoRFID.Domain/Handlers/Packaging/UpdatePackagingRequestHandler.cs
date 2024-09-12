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
    public class UpdatePackagingRequestHandler : IRequestHandler<UpdatePackagingRequest, Result<UpdatePackagingResponse>>
    {
        private readonly IPackagingRepository _packagingRepository;
        private readonly ILogger<UpdatePackagingRequestHandler> _logger;

        public UpdatePackagingRequestHandler(IPackagingRepository packagingRepository, ILogger<UpdatePackagingRequestHandler> logger)
        {
            _packagingRepository = packagingRepository;
            _logger = logger;
        }

        public async Task<Result<UpdatePackagingResponse>> Handle(UpdatePackagingRequest request, CancellationToken cancellationToken)
        {
            var packaging = await _packagingRepository.ReturnActivePackagingByIdAsync(request.Id);

            if(packaging == null)
            {
                return Result.Error<UpdatePackagingResponse>(new ExceptionApplication(RegisteredErrors.IdPackagingInvalid));
            }

            packaging.Update(request.Name);

            await _packagingRepository.UpdatePackagingAsync(packaging);

            return Result.Success(new UpdatePackagingResponse(packaging.Id, packaging.Name, packaging.IsActive));
        }
    }
}
