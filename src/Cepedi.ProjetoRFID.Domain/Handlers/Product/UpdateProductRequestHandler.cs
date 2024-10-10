using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Requests.Product;
using Cepedi.ProjetoRFID.Shared.Responses.Product;
using Cepedi.ProjetoRFID.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using Cepedi.ProjetoRFID.Domain.Services;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Product;
public class UpdateProductRequestHandler
    : IRequestHandler<UpdateProductRequest, Result<UpdateProductResponse>>
{
    private readonly ILogger<UpdateProductRequestHandler> _logger;
    private readonly IProductRepository _productRepository;
    private readonly IMinioService _minioService;

	public UpdateProductRequestHandler(IProductRepository productRepository, ILogger<UpdateProductRequestHandler> logger, IMinioService minioService)
	{
		_productRepository = productRepository;
		_logger = logger;
		_minioService = minioService;
	}

	public async Task<Result<UpdateProductResponse>> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.ReturnProductAsync(request.Id);
        if (product == null)
        {
            //return Result.Error<UpdateCategoryResponse>(new Shared.Exececoes.ExcecaoAplicacao(CadastroErros.IdPessoaInvalido));
        }

        var imageObjectName = await _minioService.UploadImageAsync(request.ImageBase64!);

        product.Update(request.IdCategory,
                        request.IdSupplier,
                        request.IdPackaging,
                        request.Name,
                        request.Description,
                        request.Weight,
                        request.ManufacDate,
                        request.DueDate,
                        request.UnitMeasurement,
                        request.BatchNumber,
                        request.Quantity,
                        request.Price,
                        request.IdReadout,
                        request.Height,
                        request.Width,
                        request.Length,
                        imageObjectName);

        await _productRepository.UpdateProductAsync(product);

        var response = new UpdateProductResponse(
            product.Id,
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
            product.ImageObjectName
        );
        return Result.Success(response);
    }
}
