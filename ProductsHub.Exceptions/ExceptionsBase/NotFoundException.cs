using System.Net;

namespace ProductsHub.Exceptions.ExceptionsBase;

public class NotFoundException : ProductsHubException
{
    public NotFoundException(string errorMessage) : base(errorMessage)
    {
    }

    public override List<string> GetErrors() => new List<string> { Message };

    public override HttpStatusCode GetErrorHttpStatusCode() => HttpStatusCode.NotFound;

}
