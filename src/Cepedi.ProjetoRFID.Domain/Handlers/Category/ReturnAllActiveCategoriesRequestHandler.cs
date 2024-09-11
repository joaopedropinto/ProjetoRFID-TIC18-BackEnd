using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Requests.Category;
using Cepedi.ProjetoRFID.Shared.Responses.Category;
using Cepedi.ProjetoRFID.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Category
{
    public class ReturnAllActiveCategoriesRequestHandler : IRequestHandler<ReturnAllActiveCategoriesRequest, Result<List<ReturnAllActiveCategoriesResponse>>>
    {
        private readonly ILogger<ReturnAllActiveCategoriesRequestHandler> _logger;
        private readonly ICategoryRepository _categoryRepository;

        public ReturnAllActiveCategoriesRequestHandler(ICategoryRepository categoryRepository, ILogger<ReturnAllActiveCategoriesRequestHandler> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<Result<List<ReturnAllActiveCategoriesResponse>>> Handle(ReturnAllActiveCategoriesRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.ReturnAllActiveCategoriesAsync();
            if (categories == null)
            {
                return Result.Error<List<ReturnAllActiveCategoriesResponse>>(new Shared.Exceptions.ExceptionApplication(RegisteredErrors.CategoryListEmpty));
            }

            var response = new List<ReturnAllActiveCategoriesResponse>();
            foreach (var category in categories)
            {
                response.Add(new ReturnAllActiveCategoriesResponse(category.Id,
                                                            category.Name,
                                                            category.Origin,
                                                            category.Color));
            }
            return Result.Success(response);
        }
    }
}
