using Cepedi.ProjetoRFID.Shared.Enums;

namespace Cepedi.ProjetoRFID.Shared.Exceptions;
public class ErrorResult
{
    public string ErrorTitle { get; set; } = default!;

    public string ErrorDescription { get; set; } = default!;

    public TypeError Tipo { get; set; }
}