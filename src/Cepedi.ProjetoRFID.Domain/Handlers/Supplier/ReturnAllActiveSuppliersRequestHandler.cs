using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Requests.Supplier;
using Cepedi.ProjetoRFID.Shared.Responses.Supplier;
using Cepedi.ProjetoRFID.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Supplier;
public class ReturnAllActiveSuppliersRequestHandler
    : IRequestHandler<ReturnAllActiveSuppliersRequest, Result<List<ReturnAllActiveSuppliersResponse>>>
{
    private readonly ILogger<ReturnAllActiveSuppliersRequestHandler> _logger;
    private readonly ISupplierRepository _supplierRepository;

    public ReturnAllActiveSuppliersRequestHandler(ISupplierRepository supplierRepository, ILogger<ReturnAllActiveSuppliersRequestHandler> logger)
    {
        _supplierRepository = supplierRepository;
        _logger = logger;
    }

    public async Task<Result<List<ReturnAllActiveSuppliersResponse>>> Handle(ReturnAllActiveSuppliersRequest request, CancellationToken cancellationToken)
    {
        var suppliers = await _supplierRepository.ReturnAllActiveSuppliersAsync();
        if (suppliers == null)
        {
            return Result.Error<List<ReturnAllActiveSuppliersResponse>>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.SupplierListEmpty));
        }

        var response = new List<ReturnAllActiveSuppliersResponse>();
        foreach (var supplier in suppliers)
        {
            response.Add(new ReturnAllActiveSuppliersResponse(supplier.Id,
                                                        supplier.Name,
                                                        supplier.Description,
                                                        supplier.PhoneNumber));
        }
        return Result.Success(response);
    }
}
