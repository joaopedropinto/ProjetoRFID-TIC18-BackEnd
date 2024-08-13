using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Requests.Category;
using Cepedi.ProjetoRFID.Shared.Responses.Category;
using Cepedi.ProjetoRFID.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Category;
public class ReturnAllCategoriesRequestHandler
    : IRequestHandler<ReturnAllCategoriesRequest, Result<List<ReturnAllCategoriesResponse>>>
{
    private readonly ILogger<ReturnAllCategoriesRequestHandler> _logger;
    private readonly ICategoryRepository _categoryRepository;

    public ReturnAllCategoriesRequestHandler(ICategoryRepository categoryRepository, ILogger<ReturnAllCategoriesRequestHandler> logger)
    {
        _categoryRepository = categoryRepository;
        _logger = logger;
    }

    public async Task<Result<List<ReturnAllCategoriesResponse>>> Handle(ReturnAllCategoriesRequest request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.ReturnAllCategoriesAsync();
        if (categories == null)
        {
            //return Result.Error<ReturnAllCategoryResponse>(new Shared.Exececoes.ExcecaoAplicacao(CadastroErros.IdPessoaInvalido));
        }

        var response = new List<ReturnAllCategoriesResponse>();
        foreach (var category in categories)
        {
            response.Add(new ReturnAllCategoriesResponse(category.Id,
                                                        category.Name,
                                                        category.Origin,
                                                        category.Color));
        }
        return Result.Success(response);
    }
}
