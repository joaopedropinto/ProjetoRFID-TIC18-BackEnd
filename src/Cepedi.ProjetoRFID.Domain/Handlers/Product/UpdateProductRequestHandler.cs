using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Requests.Product;
using Cepedi.ProjetoRFID.Shared.Responses.Product;
using Cepedi.ProjetoRFID.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Product;
public class UpdateProductRequestHandler
    : IRequestHandler<UpdateProductRequest, Result<UpdateProductResponse>>
{
    private readonly ILogger<UpdateProductRequestHandler> _logger;
    private readonly IProductRepository _productRepository;

    public UpdateProductRequestHandler(IProductRepository productRepository, ILogger<UpdateProductRequestHandler> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    public async Task<Result<UpdateProductResponse>> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.ReturnProductAsync(request.Id);
        if (product == null)
        {
            //return Result.Error<UpdateCategoryResponse>(new Shared.Exececoes.ExcecaoAplicacao(CadastroErros.IdPessoaInvalido));
        }

        product.Update(request.IdCategory, request.IdSupplier, request.Name, request.Description, request.Weight, request.ManufacDate, request.DueDate,
        request.UnitMeasurement, request.PackingType, request.BatchNumber, request.Quantity, request.Price, request.IdReadout);

        await _productRepository.UpdateProductAsync(product);

        var response = new UpdateProductResponse(product.Id,
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
                                                product.IdReadout
                                                );
        return Result.Success(response);
    }
}
