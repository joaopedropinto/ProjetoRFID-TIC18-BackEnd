using Cepedi.ProjetoRFID.Shared.Requests.Packaging;
using FluentValidation;

namespace Cepedi.ProjetoRFID.Shared.Validators.Packaging
{
    public class ReturnPackagingByIdRequestValidator : AbstractValidator<ReturnPackagingByIdRequest>
    {
        public ReturnPackagingByIdRequestValidator()
        {
            RuleFor(packaging => packaging.PackagingId)
                .NotEmpty().WithMessage("O id do tipo de embalagem deve ser informado");
        }
    }
}
