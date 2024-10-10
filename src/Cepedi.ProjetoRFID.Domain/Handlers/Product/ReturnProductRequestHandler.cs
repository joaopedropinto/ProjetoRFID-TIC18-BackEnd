using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Requests.Product;
using Cepedi.ProjetoRFID.Shared.Responses.Product;
using Cepedi.ProjetoRFID.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Product;
public class ReturnProductRequestHandler
    : IRequestHandler<ReturnProductRequest, Result<ReturnProductResponse>>
{
    private readonly ILogger<ReturnProductRequestHandler> _logger;
    private readonly IProductRepository _productRepository;

    public ReturnProductRequestHandler(IProductRepository productRepository, ILogger<ReturnProductRequestHandler> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    public async Task<Result<ReturnProductResponse>> Handle(ReturnProductRequest request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.ReturnProductAsync(request.Id);
        if (product == null)
        {
            return Result.Error<ReturnProductResponse>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.IdProductInvalid));
        }

        await _productRepository.ReturnProductAsync(product.Id);


        var response = new ReturnProductResponse(product.Id,
                                                product.IdCategory,
                                                product.IdSupplier,
                                                product.IdPackaging,
                                                product.Name,
                                                product.RfidTag,
                                                product.Description,
                                                product.Weight,
                                                product.ManufacDate,
                                                product.DueDate,
                                                product.UnitMeasurement,
                                                product.BatchNumber,
                                                product.Quantity,
                                                product.Price,
                                                product.IdReadout,
                                                product.Height,
                                                product.Width,
                                                product.Length,
                                                product.Volume,
                                                product.ImageObjectName
                                                );
        return Result.Success(response);
    }
}
