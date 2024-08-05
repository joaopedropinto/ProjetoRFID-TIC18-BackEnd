using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Requests.Product;
using Cepedi.ProjetoRFID.Shared.Responses.Product;
using Cepedi.ProjetoRFID.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Product;
public class DeleteProductRequestHandler
    : IRequestHandler<DeleteProductRequest, Result<DeleteProductResponse>>
{
    private readonly ILogger<DeleteProductRequestHandler> _logger;
    private readonly IProductRepository _productRepository;

    public DeleteProductRequestHandler(IProductRepository productRepository, ILogger<DeleteProductRequestHandler> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    public async Task<Result<DeleteProductResponse>> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.ReturnProductAsync(request.Id);
        if (product == null)
        {
            //return Result.Error<DeleteCategoryResponse>(new Shared.Exececoes.ExcecaoAplicacao(CadastroErros.IdPessoaInvalido));
        }

        await _productRepository.DeleteProductAsync(product.Id);


        var response = new DeleteProductResponse(product.Id,
                                                product.IdCategory,
                                                product.IdSupplier,
                                                product.IdTag,
                                                product.Name,
                                                product.Description,
                                                product.Weight,
                                                product.ManufacDate,
                                                product.DueDate,
                                                product.UnitMeasurement,
                                                product.PackingType,
                                                product.BatchNumber,
                                                product.Quantity,
                                                product.Price
                                                );
        return Result.Success(response);
    }
}
