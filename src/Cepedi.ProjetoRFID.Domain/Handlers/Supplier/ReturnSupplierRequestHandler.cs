using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Requests.Supplier;
using Cepedi.ProjetoRFID.Shared.Responses.Supplier;
using Cepedi.ProjetoRFID.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Supplier;
public class ReturnSupplierRequestHandler
    : IRequestHandler<ReturnSupplierRequest, Result<ReturnSupplierResponse>>
{
    private readonly ILogger<ReturnSupplierRequestHandler> _logger;
    private readonly ISupplierRepository _supplierRepository;

    public ReturnSupplierRequestHandler(ISupplierRepository supplierRepository, ILogger<ReturnSupplierRequestHandler> logger)
    {
        _supplierRepository = supplierRepository;
        _logger = logger;
    }

    public async Task<Result<ReturnSupplierResponse>> Handle(ReturnSupplierRequest request, CancellationToken cancellationToken)
    {
        var supplier = await _supplierRepository.ReturnSupplierAsync(request.Id);
        if (supplier == null)
        {
            return Result.Error<ReturnSupplierResponse>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.IdSupplierInvalid));
        }

        await _supplierRepository.ReturnSupplierAsync(supplier.Id);


        var response = new ReturnSupplierResponse(supplier.Id,
                                                supplier.Name,
                                                supplier.Description,
                                                supplier.PhoneNumber);
        return Result.Success(response);
    }
}
