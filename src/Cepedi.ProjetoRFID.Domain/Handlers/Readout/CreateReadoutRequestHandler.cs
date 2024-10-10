using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Requests.Readout;
using Cepedi.ProjetoRFID.Shared.Responses.Readout;
using Cepedi.ProjetoRFID.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Readout;

public class CreateReadoutRequestHandler
    : IRequestHandler<CreateReadoutRequest, Result<CreateReadoutResponse>>
{
    private readonly ILogger<CreateReadoutRequestHandler> _logger;
    private readonly IReadoutRepository _readoutRepository;
    private readonly IProductRepository _productRepository;

    public CreateReadoutRequestHandler(IReadoutRepository readoutRepository, ILogger<CreateReadoutRequestHandler> logger, IProductRepository productRepository)
    {
        _readoutRepository = readoutRepository;
        _logger = logger;
        _productRepository = productRepository;
    }
    public async Task<Result<CreateReadoutResponse>> Handle(CreateReadoutRequest request, CancellationToken cancellationToken)
    {
        var productTags = request.Tags;
        var validTagsIds = new List<string>();
        var IdList = new List<Guid>();

        var product = await _productRepository.GetProductsByRfidsAsync(productTags);

        var foundRfidTags = product?.Select(p => p.RfidTag).ToHashSet() ?? new HashSet<string>();
        var notFoundRfidTags = productTags.Except(foundRfidTags);

        foreach (var productId in product)
        {

            // if (productId == null)
            // {
            //     validTagsIds.Add(productId.RfidTag);
            //     return Result.Error<CreateReadoutResponse>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.IdProductInvalid));
            // }
            IdList.Add(productId.Id);
            validTagsIds.Add(productId.RfidTag);
        }
        foreach (var tag in notFoundRfidTags)
        {
            validTagsIds.Add(tag);
        }

        // if (validTagsIds.Count == 0)
        // {
        //     return Result.Error<CreateReadoutResponse>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.ProductListEmpty));
        // }

        var readout = new ReadoutEntity
        {
            ReadoutDate = DateTime.Now,
            Tags = validTagsIds
        };

        var response = new CreateReadoutResponse(readout.Id, readout.ReadoutDate, validTagsIds);
        await _readoutRepository.CreateReadoutAsync(readout);

        foreach (var idFound in IdList)
        {
            var productFound = await _productRepository.ReturnProductAsync(idFound);
            if (productFound == null)
            {
                return Result.Error<CreateReadoutResponse>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.IdProductInvalid));
            }
            productFound.IdReadout = readout.Id;
            await _productRepository.UpdateProductAsync(productFound);
        }

        return Result.Success(response);
    }
}
