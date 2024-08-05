using Cepedi.ProjetoRFID.Shared.Responses.Category;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.Category;

public class DeleteCategoryRequest : IRequest<Result<DeleteCategoryResponse>>, IValida
{
    public int Id { get; set; }
}
