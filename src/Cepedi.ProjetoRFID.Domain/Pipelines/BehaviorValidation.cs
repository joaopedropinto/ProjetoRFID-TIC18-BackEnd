using Cepedi.ProjetoRFID.Shared;
using Cepedi.ProjetoRFID.Shared.Exceptions;
using FluentValidation;
using MediatR;

namespace Cepedi.ProjetoRFID.Domain.Pipelines;
public sealed class BehaviorValidation<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, IValida
{
    private AbstractValidator<TRequest> _validator;
    public BehaviorValidation(AbstractValidator<TRequest> validator) => _validator = validator;
    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid)
        {
            return await next.Invoke();
        }

        var context = new ValidationContext<TRequest>(request);
        var erros = validationResult
            .Errors
            .GroupBy(
                x => x.PropertyName,
                x => x.ErrorMessage,
                (propertyName, errorMessages) => new
                {
                    Key = propertyName,
                    Values = errorMessages.Distinct().ToArray()
                })
            .ToDictionary(x => x.Key, x => x.Values);

        if (erros.Any())
        {
            throw new InvalidRequestExeption(erros);
        }

        return await next();
    }
}