﻿using Cepedi.ProjetoRFID.Domain.Entities;
using Cepedi.ProjetoRFID.Domain.Repositories;
using Cepedi.ProjetoRFID.Shared.Requests.Category;
using Cepedi.ProjetoRFID.Shared.Responses.Category;
using Cepedi.ProjetoRFID.Shared.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.ProjetoRFID.Domain.Handlers.Category;
public class CreateCategoryRequestHandler
    : IRequestHandler<CreateCategoryRequest, Result<CreateCategoryResponse>>
{
    private readonly ILogger<CreateCategoryRequestHandler> _logger;
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryRequestHandler(ICategoryRepository categoryRepository, ILogger<CreateCategoryRequestHandler> logger)
    {
        _categoryRepository = categoryRepository;
        _logger = logger;
    }

    public async Task<Result<CreateCategoryResponse>> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = new CategoryEntity()
        {
            Name = request.Name,
            Origin = request.Origin,
            Color = request.Color,

        };

        await _categoryRepository.CreateCategoryAsync(category);


        var response = new CreateCategoryResponse(category.Id,
                                                category.Name,
                                                category.Origin,
                                                category.Color);
        return Result.Success(response);
    }
}
