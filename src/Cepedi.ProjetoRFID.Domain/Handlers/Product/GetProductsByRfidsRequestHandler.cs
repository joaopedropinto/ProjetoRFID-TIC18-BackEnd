using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Requests.Product;
using Cepedi.ProjetoRFID.Shared.Responses.Product;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Product;

public class GetProductsByRfidsRequestHandler : IRequestHandler<GetProductsByRfidsRequest, Result<List<GetProductsByRfidsResponse>>>
{
    private readonly ILogger<GetProductsByRfidsRequestHandler> _logger;
    private readonly IProductRepository _productRepository;

    public GetProductsByRfidsRequestHandler(IProductRepository productRepository, ILogger<GetProductsByRfidsRequestHandler> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    public async Task<Result<List<GetProductsByRfidsResponse>>> Handle(GetProductsByRfidsRequest request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetProductsByRfidsAsync(request.Rfids);
        if (products == null)
        {
            //return Result.Error<GetCategoryResponse>(new Shared.Exececoes.ExcecaoAplicacao(CadastroErros.IdPessoaInvalido));
        }

        var response = products.Select(p => new GetProductsByRfidsResponse(p.Id, p.Name, p.Description, p.Weight, p.ManufacDate, p.DueDate, p.UnitMeasurement, p.PackingType, p.BatchNumber, p.Quantity, p.Price)).ToList();

        return Result.Success(response);
    }
}
