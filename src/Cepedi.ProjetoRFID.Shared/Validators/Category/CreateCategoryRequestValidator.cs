using Cepedi.ProjetoRFID.Shared.Requests.Category;
using FluentValidation;

namespace Cepedi.ProjetoRFID.Shared.Validators.Category;

public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
{
    public CreateCategoryRequestValidator()
    {
        RuleFor(Category => Category.Name)
            .NotEmpty().WithMessage("O nome da categoria deve ser informado")
            .MinimumLength(3).WithMessage("Nome da categoria deve ter no mínimo 3 caracteres")
            .MaximumLength(100).WithMessage("Nome da categoria deve ter no máximo 100 caracteres");

        RuleFor(Category => Category.Origin)
            .NotEmpty().WithMessage("A origem da categoria deve ser informado")
            .MinimumLength(3).WithMessage("Origem da categoria deve ter no mínimo 3 caracteres")
            .MaximumLength(100).WithMessage("Origem da categoria deve ter no máximo 100 caracteres");

        RuleFor(Category => Category.Color)
            .NotEmpty().WithMessage("A cor da categoria deve ser informado")
            .MinimumLength(3).WithMessage("Cor da categoria deve ter no mínimo 3 caracteres")
            .MaximumLength(100).WithMessage("Cor da categoria deve ter no máximo 100 caracteres");
    }
}
