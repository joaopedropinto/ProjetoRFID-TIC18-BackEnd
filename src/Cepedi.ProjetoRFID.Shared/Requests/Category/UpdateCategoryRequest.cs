using Cepedi.ProjetoRFID.Shared.Responses.Category;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.Category;

public class UpdateCategoryRequest : IRequest<Result<UpdateCategoryResponse>>, IValida
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Origin { get; set; }
    public string? Color { get; set; }
}
