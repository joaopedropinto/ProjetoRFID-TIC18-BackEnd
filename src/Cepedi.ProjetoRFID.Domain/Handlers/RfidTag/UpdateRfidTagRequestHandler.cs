using Cepedi.ProjetoRFID.Shared.Requests.RfidTag;
using Cepedi.ProjetoRFID.Shared.Responses.RfidTag;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.RfidTag;

public class UpdateRfidTagRequestHandler : IRequestHandler<UpdateRfidTagRequest, Result<UpdateRfidTagResponse>>
{
    private readonly ILogger<UpdateRfidTagRequestHandler> _logger;

    private readonly IRfidTagRepository _rfidTagRepository;

    public UpdateRfidTagRequestHandler(IRfidTagRepository rfidTagRepository, ILogger<UpdateRfidTagRequestHandler> logger)
    {
        _rfidTagRepository = rfidTagRepository;
        _logger = logger;
    }

    public async Task<Result<UpdateRfidTagResponse>> Handle(UpdateRfidTagRequest request, CancellationToken cancellationToken)
    {
        var rfidTag = await _rfidTagRepository.ReturnRfidTagAsync(request.Id);
        if (rfidTag == null)
        {
            //return Result.Error<UpdateRfidTagResponse>(new Shared.Exececoes.ExcecaoAplicacao(CadastroErros.IdPessoaInvalido));
        }

        rfidTag.Update(request.RfidTag);

        await _rfidTagRepository.UpdateRfidTagAsync(rfidTag);

        var response = new UpdateRfidTagResponse(rfidTag.Id, rfidTag.RfidTag);

        return Result.Success(response);
    }
}
