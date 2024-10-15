using System.Globalization;
using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Enums;
using Cepedi.ProjetoRFID.Shared.Exceptions;
using Cepedi.ProjetoRFID.Shared.Requests.Packaging;
using Cepedi.ProjetoRFID.Shared.Responses.Packaging;
using Cepedi.ProjetoRFID.Shared.Utils;
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
            var existingPackaging = await _packagingRepository.ReturnActivePackagingByNameAsync(request.Name);

            if(existingPackaging is not null) 
            {
                return Result.Error<CreatePackagingResponse>(new ExceptionApplication(RegisteredErrors.PackageNameAlreadyExists));
            }
            
            var packaging = new PackagingEntity()
            {
                Name = char.ToUpper(request.Name[0]) + request.Name.Substring(1).ToLower()
			};

            await _packagingRepository.CreatePackagingAsync(packaging);

            var response = new CreatePackagingResponse(packaging.Id, packaging.Name, packaging.IsDeleted);

            return Result.Success(response);
        }
    }
}
