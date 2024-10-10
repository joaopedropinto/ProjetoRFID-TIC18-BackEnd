using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Requests.Product;
using Cepedi.ProjetoRFID.Shared.Responses.Product;
using Cepedi.ProjetoRFID.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using Minio;
using Cepedi.ProjetoRFID.Domain.Services;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Product;
public class CreateProductRequestHandler
    : IRequestHandler<CreateProductRequest, Result<CreateProductResponse>>
{
    private readonly ILogger<CreateProductRequestHandler> _logger;
    private readonly IProductRepository _productRepository;
    private readonly IMinioClient _minioClient;
    private readonly IMinioService _minioService;

	public CreateProductRequestHandler(IProductRepository productRepository, ILogger<CreateProductRequestHandler> logger, IMinioClient minioClient, IMinioService minioService)
	{
		_productRepository = productRepository;
		_logger = logger;
		_minioClient = minioClient;
		_minioService = minioService;
	}

	public async Task<Result<CreateProductResponse>> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        string? imageObjectName = null;

        if (!string.IsNullOrEmpty(request.ImageBase64))
        {
            imageObjectName = await _minioService.UploadImageAsync(request.ImageBase64);
        }

        var product = new ProductEntity()
        {
            IdCategory = request.IdCategory,
            IdSupplier = request.IdSupplier,
            IdPackaging = request.IdPackaging,
            Name = request.Name,
            RfidTag = request.RfidTag,
            Description = request.Description,
            Weight = request.Weight,
            ManufacDate = request.ManufacDate,
            DueDate = request.DueDate,
            UnitMeasurement = request.UnitMeasurement,
            BatchNumber = request.BatchNumber,
            Quantity = request.Quantity,
            Price = request.Price,
            Height = request.Height,
            Width = request.Width,
            Length = request.Length,
            Volume = request.Height * request.Width * request.Length,
            ImageObjectName = imageObjectName
        };

        await _productRepository.CreateProductAsync(product);


        var response = new CreateProductResponse(product.Id,
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
                                                product.Height,
                                                product.Width,
                                                product.Length,
                                                product.Volume,
                                                imageObjectName
                                                );
        return Result.Success(response);
    }
}
