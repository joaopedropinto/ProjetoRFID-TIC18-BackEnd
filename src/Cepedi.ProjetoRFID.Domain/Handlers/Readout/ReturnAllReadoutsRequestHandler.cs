using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Enums;
using Cepedi.ProjetoRFID.Shared.Exceptions;
using Cepedi.ProjetoRFID.Shared.Requests.Readout;
using Cepedi.ProjetoRFID.Shared.Responses.Readout;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Readout;

public class ReturnAllReadoutsRequestHandler
    : IRequestHandler<ReturnAllReadoutsRequest, Result<List<ReturnAllReadoutsResponse>>>
{
    private readonly ILogger<ReturnAllReadoutsRequestHandler> _logger;
    private readonly IReadoutRepository _readoutRepository;

    public ReturnAllReadoutsRequestHandler(IReadoutRepository readoutRepository, ILogger<ReturnAllReadoutsRequestHandler> logger)
    {
        _readoutRepository = readoutRepository;
        _logger = logger;
    }

    public async Task<Result<List<ReturnAllReadoutsResponse>>> Handle(ReturnAllReadoutsRequest request, CancellationToken cancellationToken)
    {
        var readouts = await _readoutRepository.ReturnAllReadoutsAsync();
        if (readouts == null)
        {
            return Result.Error<List<ReturnAllReadoutsResponse>>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.ReadoutListEmpty));

        }
        var response = new List<ReturnAllReadoutsResponse>();
        foreach (var readout in readouts)
        {
            response.Add(new ReturnAllReadoutsResponse(readout.Id,
                                                        readout.ReadoutDate,
                                                        readout.Tags));
        }
        return Result.Success(response);
    }
}
