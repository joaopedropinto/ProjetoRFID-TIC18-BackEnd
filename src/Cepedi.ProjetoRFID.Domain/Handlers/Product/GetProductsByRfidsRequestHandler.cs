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

    private async Task<List<string>> GetRfidsFromApiAsync()
    {
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetAsync("http://localhost:5106/api/PortalRFID/api/GetTagsRfid?antNum=1&ipPorta=172.16.10.50:8081&tempoLeitura=10000&readUser=false&potenciaPadrao=3000");
            response.EnsureSuccessStatusCode();
            var jsonContent = await response.Content.ReadAsStringAsync();
            var readings = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(jsonContent);
            var rfids = readings.Select(r => r["epcValue"].ToString()).ToList();
            return rfids;
        }
    }

    public async Task<Result<CombinedProductResponse>> Handle(GetProductsByRfidsRequest request, CancellationToken cancellationToken)
    {
        var rfids = await GetRfidsFromApiAsync();

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
                p.BatchNumber,
                p.Quantity,
                p.Price,
                p.IdReadout,
                p.IdCategory,
                p.IdSupplier,
                p.IdPackaging,
                p.Height,
                p.Width,
                p.Length,
                p.Volume,
                p.ImageObjectName,
                p.IsDeleted
                )));
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
