using Cepedi.ProjetoRFID.Shared.Responses.Category;
using MediatR;
using OperationResult;

namespace Cepedi.ProjetoRFID.Shared.Requests.Category;

public class ReturnCategoryRequest : IRequest<Result<ReturnCategoryResponse>>, IValida
{
    public Guid Id { get; set; }
}
