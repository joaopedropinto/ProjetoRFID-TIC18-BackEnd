using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Requests.Readout;
using Cepedi.ProjetoRFID.Shared.Responses.Readout;
using Cepedi.ProjetoRFID.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Readout;
public class ReturnReadoutRequestHandler
    : IRequestHandler<ReturnReadoutRequest, Result<ReturnReadoutResponse>>
{
    private readonly ILogger<ReturnReadoutRequestHandler> _logger;
    private readonly IReadoutRepository _readoutRepository;

    public ReturnReadoutRequestHandler(IReadoutRepository readoutRepository, ILogger<ReturnReadoutRequestHandler> logger)
    {
        _readoutRepository = readoutRepository;
        _logger = logger;
    }

    public async Task<Result<ReturnReadoutResponse>> Handle(ReturnReadoutRequest request, CancellationToken cancellationToken)
    {
        var readout = await _readoutRepository.ReturnReadoutAsync(request.Id);
        if (readout == null)
        {
            return Result.Error<ReturnReadoutResponse>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.IdReadoutInvalid));
        }
        await _readoutRepository.ReturnReadoutAsync(readout.Id);

        var response = new ReturnReadoutResponse(readout.Id,
                                                readout.ReadoutDate,
                                                readout.Products);
        return Result.Success(response);
    }
}