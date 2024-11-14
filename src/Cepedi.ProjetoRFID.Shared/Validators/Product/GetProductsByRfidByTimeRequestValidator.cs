using Cepedi.ProjetoRFID.Shared.Requests.Product;
using FluentValidation;

namespace Cepedi.ProjetoRFID.Shared.Validators.Product;

public class GetProductsByRfidByTimeRequestValidator : AbstractValidator<GetProductsByRfidsByTimeRequest>
{
    public GetProductsByRfidByTimeRequestValidator()
    {
        RuleFor(request => request.ReadingTime)
            .NotNull()
            .WithMessage("O tempo de leitura é obrigatório")
            .GreaterThan(1000)
            .WithMessage("Tempo de leitura inválido");
    }
}
