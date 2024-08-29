using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Requests.Product;
using Cepedi.ProjetoRFID.Shared.Responses.Product;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using System.IO;
using System.Text.Json;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Product;

public class GetProductsByRfidsRequestHandler : IRequestHandler<GetProductsByRfidsRequest, Result<CombinedProductResponse>>
{
    private readonly ILogger<GetProductsByRfidsRequestHandler> _logger;
    private readonly IProductRepository _productRepository;

    public GetProductsByRfidsRequestHandler(IProductRepository productRepository, ILogger<GetProductsByRfidsRequestHandler> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    public async Task<Result<CombinedProductResponse>> Handle(GetProductsByRfidsRequest request, CancellationToken cancellationToken)
    {
        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var projectRoot = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\..\"));
        var filePath = Path.Combine(projectRoot, "Cepedi.ProjetoRFID.Data", "DataBase", "reading.json");

        var jsonContent = await System.IO.File.ReadAllTextAsync(filePath);
        var readings = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(jsonContent);
        var rfids = readings.Select(r => r["rfid"].ToString()).ToList();

        var products = await _productRepository.GetProductsByRfidsAsync(rfids);

        var productResponses = new List<GetProductsByRfidsResponse>();
        var notFoundResponses = new List<RfidTagsNotFoundResponse>();

        if (products != null && products.Any())
        {
            productResponses.AddRange(products.Select(p => new GetProductsByRfidsResponse(
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
                p.Price)));
        }

        var foundRfidTags = products?.Select(p => p.RfidTag).ToHashSet() ?? new HashSet<string>();
        var notFoundRfidTags = rfids.Except(foundRfidTags);

        foreach (var notFoundRfid in notFoundRfidTags)
        {
            notFoundResponses.Add(new RfidTagsNotFoundResponse(notFoundRfid));
        }

        var response = new CombinedProductResponse
        {
            Products = productResponses,
            NotFoundResponses = notFoundResponses
        };

        return Result.Success(response);
    }
}
