using System.Net;

namespace ProductsHub.Exceptions.ExceptionsBase;

public abstract class ProductsHubException : SystemException
{
    public ProductsHubException(string errorMessage) : base(errorMessage)
    {
        
    }

    public abstract List<string> GetErrors();

    public abstract HttpStatusCode GetErrorHttpStatusCode();

}
