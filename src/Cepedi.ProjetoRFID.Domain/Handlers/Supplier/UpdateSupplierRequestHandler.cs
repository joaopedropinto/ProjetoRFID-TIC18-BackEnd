using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Requests.Supplier;
using Cepedi.ProjetoRFID.Shared.Responses.Supplier;
using Cepedi.ProjetoRFID.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Supplier;
public class UpdateSupplierRequestHandler
    : IRequestHandler<UpdateSupplierRequest, Result<UpdateSupplierResponse>>
{
    private readonly ILogger<UpdateSupplierRequestHandler> _logger;
    private readonly ISupplierRepository _supplierRepository;

    public UpdateSupplierRequestHandler(ISupplierRepository supplierRepository, ILogger<UpdateSupplierRequestHandler> logger)
    {
        _supplierRepository = supplierRepository;
        _logger = logger;
    }

    public async Task<Result<UpdateSupplierResponse>> Handle(UpdateSupplierRequest request, CancellationToken cancellationToken)
    {
        var supplier = await _supplierRepository.ReturnSupplierAsync(request.Id);
        if (supplier == null)
        {
            //return Result.Error<UpdateSupplierResponse>(new Shared.Exececoes.ExcecaoAplicacao(CadastroErros.IdPessoaInvalido));
        }

        supplier.Update(request.Name, request.Description, request.PhoneNumber);

        await _supplierRepository.UpdateSupplierAsync(supplier);

        var response = new UpdateSupplierResponse(supplier.Id,
                                                supplier.Name,
                                                supplier.Description,
                                                supplier.PhoneNumber);
        return Result.Success(response);
    }
}
