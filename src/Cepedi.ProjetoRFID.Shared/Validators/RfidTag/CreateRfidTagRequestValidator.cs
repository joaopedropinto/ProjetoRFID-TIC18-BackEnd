using Cepedi.ProjetoRFID.Shared.Requests.RfidTag;
using FluentValidation;

namespace Cepedi.ProjetoRFID.Shared.Validators.RfidTag;

public class CreateRfidTagRequestValidator : AbstractValidator<CreateRfidTagRequest>
{
    public CreateRfidTagRequestValidator()
    {
        RuleFor(x => x.RfidTag)
            .NotEmpty()
            .WithMessage("RfidTag is required");
    }
}
