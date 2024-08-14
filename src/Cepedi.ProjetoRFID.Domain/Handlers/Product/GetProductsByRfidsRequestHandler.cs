using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Requests.Product;
using Cepedi.ProjetoRFID.Shared.Responses.Product;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using System.IO;
using System.Text.Json;

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
        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var projectRoot = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\..\"));
        var filePath = Path.Combine(projectRoot, "Cepedi.ProjetoRFID.Data", "DataBase", "reading.json");

        var jsonContent = await System.IO.File.ReadAllTextAsync(filePath);

        var readings = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(jsonContent);

        var rfids = readings.Select(r => r["rfid"].ToString()).ToList();

        var products = await _productRepository.GetProductsByRfidsAsync(rfids);

        if (products == null || !products.Any())
        {
            // return Result.Error<List<GetProductsByRfidsResponse>>("Nenhum produto encontrado.");
        }

        // Mapeia os produtos para o response
        var response = products.Select(p => new GetProductsByRfidsResponse(
            p.Id,
            p.Name,
            p.RfidTag,
            p.Description,
            p.Weight,
            p.ManufacDate,
            p.DueDate,
            p.UnitMeasurement,
            p.PackingType,
            p.BatchNumber,
            p.Quantity,
            p.Price)).ToList();

        return Result.Success(response);
    }
}
