using Cepedi.ProjetoRFID.Shared.Requests.RfidTag;
using Cepedi.ProjetoRFID.Shared.Responses.RfidTag;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.RfidTag;

public class ReturnAllRfidTagsRequestHandler : IRequestHandler<ReturnAllRfidTagsRequest, Result<List<ReturnAllRfidTagsResponse>>>
{
    private readonly ILogger<ReturnAllRfidTagsRequestHandler> _logger;

    private readonly IRfidTagRepository _rfidTagRepository;

    public ReturnAllRfidTagsRequestHandler(IRfidTagRepository rfidTagRepository, ILogger<ReturnAllRfidTagsRequestHandler> logger)
    {
        _rfidTagRepository = rfidTagRepository;
        _logger = logger;
    }

    public async Task<Result<List<ReturnAllRfidTagsResponse>>> Handle(ReturnAllRfidTagsRequest request, CancellationToken cancellationToken)
    {
        var rfidTags = await _rfidTagRepository.ReturnAllRfidTagsAsync();
        if (rfidTags == null)
        {
            //return Result.Error<ReturnAllRfidTagResponse>(new Shared.Exececoes.ExcecaoAplicacao(CadastroErros.IdPessoaInvalido));
        }

        var response = new List<ReturnAllRfidTagsResponse>();
        foreach (var rfidTag in rfidTags)
        {
            response.Add(new ReturnAllRfidTagsResponse(rfidTag.Id,
                                                        rfidTag.RfidTag));
        }
        return Result.Success(response);
    }
}
