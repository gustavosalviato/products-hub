using System.Net;

namespace ProductsHub.Exceptions.ExceptionsBase;

public class ErrorOnValidationException : ProductsHubException
{
    private readonly List<string> _errors;

    public ErrorOnValidationException(List<String> errorMessages) : base(string.Empty)
    {
        _errors = errorMessages;
    }


    public override List<string> GetErrors() => _errors;

    public override HttpStatusCode GetErrorHttpStatusCode()  => HttpStatusCode.BadRequest;
}
