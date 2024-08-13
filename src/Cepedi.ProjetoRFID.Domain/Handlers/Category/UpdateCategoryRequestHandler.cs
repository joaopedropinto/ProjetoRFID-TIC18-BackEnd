using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Requests.Category;
using Cepedi.ProjetoRFID.Shared.Responses.Category;
using Cepedi.ProjetoRFID.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Category;
public class UpdateCategoryRequestHandler
    : IRequestHandler<UpdateCategoryRequest, Result<UpdateCategoryResponse>>
{
    private readonly ILogger<UpdateCategoryRequestHandler> _logger;
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryRequestHandler(ICategoryRepository categoryRepository, ILogger<UpdateCategoryRequestHandler> logger)
    {
        _categoryRepository = categoryRepository;
        _logger = logger;
    }

    public async Task<Result<UpdateCategoryResponse>> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.ReturnCategoryAsync(request.Id);
        if (category == null)
        {
            //return Result.Error<UpdateCategoryResponse>(new Shared.Exececoes.ExcecaoAplicacao(CadastroErros.IdPessoaInvalido));
        }

        category.Update(request.Name, request.Origin, request.Color);

        await _categoryRepository.UpdateCategoryAsync(category);

        var response = new UpdateCategoryResponse(category.Id,
                                                category.IdProduct,
                                                category.Name,
                                                category.Origin,
                                                category.Color);
        return Result.Success(response);
    }
}
