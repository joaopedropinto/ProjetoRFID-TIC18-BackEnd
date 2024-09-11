using Cepedi.ProjetoRFID.Shared.Requests.Packaging;
using FluentValidation;

namespace Cepedi.ProjetoRFID.Shared.Validators.Packaging
{
    public class UpdatePackagingRequestValidator : AbstractValidator<UpdatePackagingRequest>
    {
        public UpdatePackagingRequestValidator()
        {
            RuleFor(packaging => packaging.Id)
                .NotEmpty().WithMessage("O id do tipo de embalagem deve ser informado");

            RuleFor(packaging => packaging.Name)
                .NotEmpty().WithMessage("O nome do tipo de embalegem deve ser informado")
                .MinimumLength(3).WithMessage("O nome do tipo de embalegem deve ter no mínimo 3 caracteres")
                .MaximumLength(100).WithMessage("O nome do tipo de embalegem deve ter no máximo 100 caracteres");
        }
    }
}
