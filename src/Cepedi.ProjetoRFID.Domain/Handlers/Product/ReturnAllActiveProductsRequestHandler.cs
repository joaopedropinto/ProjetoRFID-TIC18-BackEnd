using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Requests.Product;
using Cepedi.ProjetoRFID.Shared.Responses.Product;
using Cepedi.ProjetoRFID.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Product;
public class ReturnAllActiveProductsRequestHandler
    : IRequestHandler<ReturnAllActiveProductsRequest, Result<List<ReturnAllActiveProductsResponse>>>
{
    private readonly ILogger<ReturnAllActiveProductsRequestHandler> _logger;
    private readonly IProductRepository _productRepository;

    public ReturnAllActiveProductsRequestHandler(IProductRepository productRepository, ILogger<ReturnAllActiveProductsRequestHandler> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    public async Task<Result<List<ReturnAllActiveProductsResponse>>> Handle(ReturnAllActiveProductsRequest request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.ReturnAllActiveProductsAsync();
        if (products == null)
        {
            return Result.Error<List<ReturnAllActiveProductsResponse>>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.ProductListEmpty));
        }

        var response = new List<ReturnAllActiveProductsResponse>();
        foreach (var product in products)
        {
            response.Add(new ReturnAllActiveProductsResponse(product.Id,
                                                product.IdCategory,
                                                product.IdSupplier,
                                                product.Name,
                                                product.RfidTag,
                                                product.Description,
                                                product.Weight,
                                                product.ManufacDate,
                                                product.DueDate,
                                                product.UnitMeasurement,
                                                product.PackingType,
                                                product.BatchNumber,
                                                product.Quantity,
                                                product.Price,
                                                product.IdReadout,
                                                product.Height,
                                                product.Width,
                                                product.Length,
                                                product.Volume
                                                ));

        }
        return Result.Success(response);
    }
}
