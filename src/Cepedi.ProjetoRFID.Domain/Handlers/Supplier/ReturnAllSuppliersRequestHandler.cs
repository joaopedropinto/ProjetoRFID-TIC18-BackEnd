using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Requests.Supplier;
using Cepedi.ProjetoRFID.Shared.Responses.Supplier;
using Cepedi.ProjetoRFID.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Supplier;
public class ReturnAllSuppliersRequestHandler
    : IRequestHandler<ReturnAllSuppliersRequest, Result<List<ReturnAllSuppliersResponse>>>
{
    private readonly ILogger<ReturnAllSuppliersRequestHandler> _logger;
    private readonly ISupplierRepository _supplierRepository;

    public ReturnAllSuppliersRequestHandler(ISupplierRepository supplierRepository, ILogger<ReturnAllSuppliersRequestHandler> logger)
    {
        _supplierRepository = supplierRepository;
        _logger = logger;
    }

    public async Task<Result<List<ReturnAllSuppliersResponse>>> Handle(ReturnAllSuppliersRequest request, CancellationToken cancellationToken)
    {
        var suppliers = await _supplierRepository.ReturnAllSuppliersAsync();
        if (suppliers == null)
        {
            //return Result.Error<ReturnAllSuppliersResponse>(new Shared.Exececoes.ExcecaoAplicacao(CadastroErros.IdPessoaInvalido));
        }

        var response = new List<ReturnAllSuppliersResponse>();
        foreach (var supplier in suppliers)
        {
            response.Add(new ReturnAllSuppliersResponse(supplier.Id,
                                                        supplier.IdProduct,
                                                        supplier.Name,
                                                        supplier.Description,
                                                        supplier.PhoneNumber));
        }
        return Result.Success(response);
    }
}
