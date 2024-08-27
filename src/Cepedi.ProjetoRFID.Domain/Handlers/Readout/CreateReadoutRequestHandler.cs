using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Requests.Readout;
using Cepedi.ProjetoRFID.Shared.Responses.Readout;
using Cepedi.ProjetoRFID.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Readout;

public class CreateReadoutRequestHandler
    : IRequestHandler<CreateReadoutRequest, Result<CreateReadoutResponse>>
{
    private readonly ILogger<CreateReadoutRequestHandler> _logger;
    private readonly IReadoutRepository _readoutRepository;
    private readonly IProductRepository _productRepository;

    public CreateReadoutRequestHandler(IReadoutRepository readoutRepository, ILogger<CreateReadoutRequestHandler> logger, IProductRepository productRepository)
    {
        _readoutRepository = readoutRepository;
        _logger = logger;
        _productRepository = productRepository;
    }
    public async Task<Result<CreateReadoutResponse>> Handle(CreateReadoutRequest request, CancellationToken cancellationToken)
    {
        var productIds = request.Products; 
        var validProductIds = new List<Guid>();

        foreach (var productId in productIds)
        {
            var product = await _productRepository.ReturnProductAsync(productId);

            if (product == null)
            {
                return Result.Error<CreateReadoutResponse>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.IdProductInvalid));
            }

            validProductIds.Add(productId);
        }

        if (validProductIds.Count == 0)
        {
            return Result.Error<CreateReadoutResponse>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.ProductListEmpty));
        }

        var readout = new ReadoutEntity
        {
            ReadoutDate = request.ReadoutDate,
            Products = validProductIds
        };

        await _readoutRepository.CreateReadoutAsync(readout);

        var response = new CreateReadoutResponse(readout.Id, readout.ReadoutDate, validProductIds);
        return Result.Success(response);
    }
}
