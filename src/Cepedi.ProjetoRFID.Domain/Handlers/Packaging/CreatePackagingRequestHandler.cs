using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Requests.Packaging;
using Cepedi.ProjetoRFID.Shared.Responses.Packaging;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Packaging
{
    public class CreatePackagingRequestHandler : IRequestHandler<CreatePackagingRequest, Result<CreatePackagingResponse>>
    {
        private readonly IPackagingRepository _packagingRepository;
        private readonly ILogger<CreatePackagingRequestHandler> _logger;

        public CreatePackagingRequestHandler(ILogger<CreatePackagingRequestHandler> logger, IPackagingRepository packagingRepository)
        {
            _logger = logger;
            _packagingRepository = packagingRepository;
        }

        public async Task<Result<CreatePackagingResponse>> Handle(CreatePackagingRequest request, CancellationToken cancellationToken)
        {
            var packaging = new PackagingEntity()
            {
                Name = request.Name
            };

            await _packagingRepository.CreatePackagingAsync(packaging);

            var response = new CreatePackagingResponse(packaging.Id, packaging.Name, packaging.IsActive);

            return Result.Success(response);
        }
    }
}
