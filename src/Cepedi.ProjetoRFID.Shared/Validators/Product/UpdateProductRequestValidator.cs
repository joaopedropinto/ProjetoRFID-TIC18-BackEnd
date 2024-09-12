using Cepedi.ProjetoRFID.Shared.Requests.Product;
using FluentValidation;

namespace Cepedi.ProjetoRFID.Shared.Validators.Product;

public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductRequestValidator()
    {

        RuleFor(Product => Product.Id)
            .NotEmpty().WithMessage("O Id do produto é obrigatório.");

        RuleFor(Product => Product.IdCategory)
            .NotEmpty().WithMessage("O Id da categoria é obrigatório.");

        RuleFor(Product => Product.IdSupplier)
            .NotEmpty().WithMessage("O Id do fornecedor é obrigatório.");

        RuleFor(Product => Product.Name)
            .NotEmpty().WithMessage("O nome do produto deve ser informado")
            .MinimumLength(3).WithMessage("Nome do produto deve ter no mínimo 3 caracteres")
            .MaximumLength(100).WithMessage("Nome do produto deve ter no máximo 100 caracteres");

        RuleFor(Product => Product.Description)
            .NotEmpty().WithMessage("A descricão do produto deve ser informado")
            .MinimumLength(3).WithMessage("Descricão do produto deve ter no mínimo 3 caracteres")
            .MaximumLength(100).WithMessage("Descricão do produto deve ter no máximo 100 caracteres");

        RuleFor(Product => Product.Weight)
            .NotNull().WithMessage("O peso do produto deve ser informado")
            .GreaterThan(0).WithMessage("Peso do produto inválido.");

        RuleFor(Product => Product.ManufacDate)
            .NotNull().WithMessage("A data de fabricação do produto deve ser informado")
            .Must(dataHora => dataHora != default(DateTime)).WithMessage("Data deve ser valida");

        RuleFor(Product => Product.DueDate)
            .NotNull().WithMessage("A data de validade do produto deve ser informado")
            .Must(dataHora => dataHora != default(DateTime)).WithMessage("Data deve ser valida");

        RuleFor(Product => Product.UnitMeasurement)
            .NotEmpty().WithMessage("A unidade de medida do produto deve ser informado")
            .MinimumLength(3).WithMessage("Unidade de medida do produto deve ter no mínimo 3 caracteres")
            .MaximumLength(100).WithMessage("Unidade de medida do produto deve ter no máximo 100 caracteres");

        RuleFor(Product => Product.IdPackaging)
            .NotEmpty().WithMessage("O id do tipo de embalagem do produto deve ser informado");

        RuleFor(Product => Product.BatchNumber)
            .NotEmpty().WithMessage("O número de lote do produto deve ser informado")
            .MinimumLength(3).WithMessage("Número de lote do produto deve ter no mínimo 3 caracteres")
            .MaximumLength(100).WithMessage("Número de lote do produto deve ter no máximo 100 caracteres");

        RuleFor(Product => Product.Quantity)
            .NotNull().WithMessage("A quantidade do produto deve ser informado")
            .GreaterThan(0).WithMessage("Quantidade do produto inválido.");

        RuleFor(Product => Product.Price)
            .NotNull().WithMessage("O valor do produto deve ser informado")
            .GreaterThan(0).WithMessage("Valor do produto inválido.");
    }
}
