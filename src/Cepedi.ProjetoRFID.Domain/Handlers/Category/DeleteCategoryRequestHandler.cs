using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Requests.Category;
using Cepedi.ProjetoRFID.Shared.Responses.Category;
using Cepedi.ProjetoRFID.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Category;
public class DeleteCategoryRequestHandler
    : IRequestHandler<DeleteCategoryRequest, Result<DeleteCategoryResponse>>
{
    private readonly ILogger<DeleteCategoryRequestHandler> _logger;
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryRequestHandler(ICategoryRepository categoryRepository, ILogger<DeleteCategoryRequestHandler> logger)
    {
        _categoryRepository = categoryRepository;
        _logger = logger;
    }

    public async Task<Result<DeleteCategoryResponse>> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.ReturnCategoryAsync(request.Id);
        if (category == null)
        {
            return Result.Error<DeleteCategoryResponse>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.IdCategoryInvalid));
        }

        await _categoryRepository.DeleteCategoryAsync(category.Id);


        var response = new DeleteCategoryResponse(category.Id,
                                                category.Name,
                                                category.Origin,
                                                category.Color);
        return Result.Success(response);
    }
}
