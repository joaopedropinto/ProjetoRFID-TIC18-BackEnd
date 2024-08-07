using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Requests.Supplier;
using Cepedi.ProjetoRFID.Shared.Responses.Supplier;
using Cepedi.ProjetoRFID.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Supplier;
public class DeleteSupplierRequestHandler
    : IRequestHandler<DeleteSupplierRequest, Result<DeleteSupplierResponse>>
{
    private readonly ILogger<DeleteSupplierRequestHandler> _logger;
    private readonly ISupplierRepository _supplierRepository;

    public DeleteSupplierRequestHandler(ISupplierRepository supplierRepository, ILogger<DeleteSupplierRequestHandler> logger)
    {
        _supplierRepository = supplierRepository;
        _logger = logger;
    }

    public async Task<Result<DeleteSupplierResponse>> Handle(DeleteSupplierRequest request, CancellationToken cancellationToken)
    {
        var supplier = await _supplierRepository.ReturnSupplierAsync(request.Id);
        if (supplier == null)
        {
            //return Result.Error<DeleteSupplierResponse>(new Shared.Exececoes.ExcecaoAplicacao(CadastroErros.IdPessoaInvalido));
        }

        await _supplierRepository.DeleteSupplierAsync(supplier.Id);


        var response = new DeleteSupplierResponse(supplier.Id,
                                                supplier.IdProduct,
                                                supplier.Name,
                                                supplier.Description,
                                                supplier.PhoneNumber);
        return Result.Success(response);
    }
}
