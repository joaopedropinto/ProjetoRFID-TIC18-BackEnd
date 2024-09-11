using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Requests.Product;
using Cepedi.ProjetoRFID.Shared.Responses.Product;
using Cepedi.ProjetoRFID.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Product;
public class CreateProductRequestHandler
    : IRequestHandler<CreateProductRequest, Result<CreateProductResponse>>
{
    private readonly ILogger<CreateProductRequestHandler> _logger;
    private readonly IProductRepository _productRepository;

    public CreateProductRequestHandler(IProductRepository productRepository, ILogger<CreateProductRequestHandler> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    public async Task<Result<CreateProductResponse>> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        // var product = await _productRepository.ReturnProductAsync(request.Id);
        // if (product == null)
        // {
        //     //return Result.Error<CreateProductResponse>(new Shared.Exececoes.ExcecaoAplicacao(CadastroErros.IdPessoaInvalido));
        // }

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
                                                product.Volume
                                                );
        return Result.Success(response);
    }
}
