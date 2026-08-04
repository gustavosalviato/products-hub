using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductsHub.Communication.Responses;
using ProductsHub.Exceptions.ExceptionsBase;

namespace ProductsHub.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ProductsHubException productsHubException)
        {

            context.HttpContext.Response.StatusCode = (int)productsHubException.GetErrorHttpStatusCode();

            context.Result = new ObjectResult(new ResponseErrorMessagesJson(productsHubException.GetErrors()));

        }
        else
        {
            ThrowUnknowException(context);
        }
    }

    private void ThrowUnknowException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorMessagesJson("Unknow error."));
    }
}
