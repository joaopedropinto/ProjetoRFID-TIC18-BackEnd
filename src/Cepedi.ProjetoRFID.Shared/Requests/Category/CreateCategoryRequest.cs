using Cepedi.ProjetoRFID.Shared.Responses.Category;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.Category;

public class CreateCategoryRequest : IRequest<Result<CreateCategoryResponse>>, IValida
{
    public required string Name { get; set; }
    public required string Origin { get; set; }
    public required string Color { get; set; }
    public int IdProduct { get; set; }
}
