﻿using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Requests.Product;
using Cepedi.ProjetoRFID.Shared.Responses.Product;
using Cepedi.ProjetoRFID.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Product;
public class ReturnAllProductsRequestHandler
    : IRequestHandler<ReturnAllProductsRequest, Result<List<ReturnAllProductsResponse>>>
{
    private readonly ILogger<ReturnAllProductsRequestHandler> _logger;
    private readonly IProductRepository _productRepository;

    public ReturnAllProductsRequestHandler(IProductRepository productRepository, ILogger<ReturnAllProductsRequestHandler> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    public async Task<Result<List<ReturnAllProductsResponse>>> Handle(ReturnAllProductsRequest request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.ReturnAllProductsAsync();
        if (products == null)
        {
            return Result.Error<List<ReturnAllProductsResponse>>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.ProductListEmpty));
        }

        var response = new List<ReturnAllProductsResponse>();
        foreach (var product in products)
        {
            response.Add(new ReturnAllProductsResponse(product.Id,
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
                                                product.IsDeleted,
                                                product.ImageObjectName
                                                ));

        }
        return Result.Success(response);
    }
}
