using Cepedi.ProjetoRFID.Shared.Enums;
using Cepedi.ProjetoRFID.Shared.Exceptions;

namespace Cepedi.ProjetoRFID.Shared.Exceptions;
public class InvalidRequestExeption : ExceptionApplication
{
    public InvalidRequestExeption(IDictionary<string, string[]> errors)
        : base(RegisteredErrors.InvalidData) =>
        Errors = errors.Select(e => $"{e.Key}: {string.Join(", ", e.Value)}");

    public IEnumerable<string> Errors { get; }
}
