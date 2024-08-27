using Cepedi.ProjetoRFID.Shared.Requests.Readout;
using FluentValidation;
namespace Cepedi.ProjetoRFID.Shared.Validators.Readout;

public class CreateReadoutRequestValidator : AbstractValidator<CreateReadoutRequest>
{
    public CreateReadoutRequestValidator()
    {
        RuleFor(Readout => Readout.ReadoutDate)
        .NotNull().WithMessage("A data de realização da leitura deve ser informada")
        .Must(dataHora => dataHora != default(DateTime)).WithMessage("Data deve ser valida");

        RuleFor(Readout => Readout.Products)
        .NotNull().WithMessage("Os produtos devem ser informados");
    }
}
