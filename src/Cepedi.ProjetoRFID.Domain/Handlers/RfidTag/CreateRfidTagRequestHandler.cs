using Cepedi.ProjetoRFID.Shared.Requests.RfidTag;
using Cepedi.ProjetoRFID.Shared.Responses.RfidTag;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.RfidTag;

public class CreateRfidTagRequestHandler : IRequestHandler<CreateRfidTagRequest, Result<CreateRfidTagResponse>>
{
    private readonly ILogger<CreateRfidTagRequestHandler> _logger;
    private readonly IRfidTagRepository _rfidTagRepository;

    public CreateRfidTagRequestHandler(IRfidTagRepository rfidTagRepository, ILogger<CreateRfidTagRequestHandler> logger)
    {
        _rfidTagRepository = rfidTagRepository;
        _logger = logger;
    }

    public async Task<Result<CreateRfidTagResponse>> Handle(CreateRfidTagRequest request, CancellationToken cancellationToken)
    {
        var rfidTag = new RfidTagEntity()
        {
            RfidTag = request.RfidTag,
        };

        await _rfidTagRepository.CreateRfidTagAsync(rfidTag);

        var response = new CreateRfidTagResponse(rfidTag.Id, rfidTag.RfidTag);

        return Result.Success(response);
    }
}
