using Cepedi.ProjetoRFID.Shared.Requests.RfidTag;
using Cepedi.ProjetoRFID.Shared.Responses.RfidTag;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.RfidTag;

public class DeleteRfidTagRequestHandler : IRequestHandler<DeleteRfidTagRequest, Result<DeleteRfidTagResponse>>
{
    private readonly ILogger<DeleteRfidTagRequestHandler> _logger;

    private readonly IRfidTagRepository _rfidTagRepository;

    public DeleteRfidTagRequestHandler(IRfidTagRepository rfidTagRepository, ILogger<DeleteRfidTagRequestHandler> logger)
    {
        _rfidTagRepository = rfidTagRepository;
        _logger = logger;
    }

    public async Task<Result<DeleteRfidTagResponse>> Handle(DeleteRfidTagRequest request, CancellationToken cancellationToken)
    {
        var rfidTag = await _rfidTagRepository.ReturnRfidTagAsync(request.Id);
        if (rfidTag == null)
        {
            //return Result.Error<DeleteRfidTagResponse>(new Shared.Exececoes.ExcecaoAplicacao(CadastroErros.IdPessoaInvalido));
        }

        await _rfidTagRepository.DeleteRfidTagAsync(rfidTag.Id);

        var response = new DeleteRfidTagResponse(rfidTag.Id, rfidTag.RfidTag);
        return Result.Success(response);
    }
}
