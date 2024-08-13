using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Requests.Supplier;
using Cepedi.ProjetoRFID.Shared.Responses.Supplier;
using Cepedi.ProjetoRFID.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Supplier;
public class CreateSupplierRequestHandler
    : IRequestHandler<CreateSupplierRequest, Result<CreateSupplierResponse>>
{
    private readonly ILogger<CreateSupplierRequestHandler> _logger;
    private readonly ISupplierRepository _supplierRepository;

    public CreateSupplierRequestHandler(ISupplierRepository supplierRepository, ILogger<CreateSupplierRequestHandler> logger)
    {
        _supplierRepository = supplierRepository;
        _logger = logger;
    }

    public async Task<Result<CreateSupplierResponse>> Handle(CreateSupplierRequest request, CancellationToken cancellationToken)
    {
        var supplier = new SupplierEntity()
        {
            Name = request.Name,
            Description = request.Description,
            PhoneNumber = request.PhoneNumber,

        };

        await _supplierRepository.CreateSupplierAsync(supplier);


        var response = new CreateSupplierResponse(supplier.Id,
                                                supplier.Name,
                                                supplier.Description,
                                                supplier.PhoneNumber);
        return Result.Success(response);
    }
}
