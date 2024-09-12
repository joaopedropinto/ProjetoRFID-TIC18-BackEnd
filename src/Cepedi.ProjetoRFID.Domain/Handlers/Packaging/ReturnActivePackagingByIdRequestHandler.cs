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
    public class ReturnActivePackagingByIdRequestHandler
        : IRequestHandler<ReturnActivePackagingByIdRequest, Result<ReturnPackagingResponse>>
    {
        private readonly IPackagingRepository _packagingRepository;
        private readonly ILogger<ReturnActivePackagingByIdRequestHandler> _logger;

        public ReturnActivePackagingByIdRequestHandler(IPackagingRepository packagingRepository, ILogger<ReturnActivePackagingByIdRequestHandler> logger)
        {
            _packagingRepository = packagingRepository;
            _logger = logger;
        }


        public async Task<Result<ReturnPackagingResponse>> Handle(ReturnActivePackagingByIdRequest request, CancellationToken cancellationToken)
        {
            var packaging = await _packagingRepository.ReturnActivePackagingByIdAsync(request.PackagingId);

            return packaging is null
               ? Result.Error<ReturnPackagingResponse>(new ExceptionApplication(RegisteredErrors.IdPackagingInvalid))
               : Result.Success(new ReturnPackagingResponse(packaging.Id, packaging.Name, packaging.IsActive));
        }
    }
}
