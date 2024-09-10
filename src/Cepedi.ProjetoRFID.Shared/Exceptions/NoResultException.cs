using Cepedi.ProjetoRFID.Shared.Enums;

namespace Cepedi.ProjetoRFID.Shared.Exceptions;
public class NoResultException : ExceptionApplication
{
    public NoResultException() : 
        base(RegisteredErrors.NoResults)
    {
    }
}