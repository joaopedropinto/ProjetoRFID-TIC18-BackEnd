using Cepedi.ProjetoRFID.Shared.Requests.RfidTag;
using FluentValidation;

namespace Cepedi.ProjetoRFID.Shared.Validators.RfidTag;

public class UpdateRfidTagRequestValidator : AbstractValidator<UpdateRfidTagRequest>
{
    public UpdateRfidTagRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required");

        RuleFor(x => x.RfidTag)
            .NotEmpty()
            .WithMessage("RfidTag is required");
    }
}
