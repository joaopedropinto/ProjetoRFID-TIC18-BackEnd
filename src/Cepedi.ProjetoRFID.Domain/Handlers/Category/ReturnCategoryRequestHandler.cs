using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Requests.Category;
using Cepedi.ProjetoRFID.Shared.Responses.Category;
using Cepedi.ProjetoRFID.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Category;
public class ReturnCategoryRequestHandler
    : IRequestHandler<ReturnCategoryRequest, Result<ReturnCategoryResponse>>
{
    private readonly ILogger<ReturnCategoryRequestHandler> _logger;
    private readonly ICategoryRepository _categoryRepository;

    public ReturnCategoryRequestHandler(ICategoryRepository categoryRepository, ILogger<ReturnCategoryRequestHandler> logger)
    {
        _categoryRepository = categoryRepository;
        _logger = logger;
    }

    public async Task<Result<ReturnCategoryResponse>> Handle(ReturnCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.ReturnCategoryAsync(request.Id);
        if (category == null)
        {
            //return Result.Error<ReturnCategoryResponse>(new Shared.Exececoes.ExcecaoAplicacao(CadastroErros.IdPessoaInvalido));
        }

        await _categoryRepository.ReturnCategoryAsync(category.Id);


        var response = new ReturnCategoryResponse(category.Id,
                                                category.Name,
                                                category.Origin,
                                                category.Color);
        return Result.Success(response);
    }
}
