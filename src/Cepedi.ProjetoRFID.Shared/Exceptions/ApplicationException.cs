namespace Cepedi.ProjetoRFID.Shared.Exceptions;
public class ExceptionApplication : Exception
{
    public ExceptionApplication(ErrorResult error)
     : base(error.ErrorDescription) => ErrorResult = error;

    public ErrorResult ErrorResult { get; set; }
}