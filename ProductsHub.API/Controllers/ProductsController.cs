using Microsoft.AspNetCore.Mvc;
using ProductsHub.API.UseCases.Clients.GetAll;
using ProductsHub.API.UseCases.Products.Register;
using ProductsHub.Communication.Requests;
using ProductsHub.Communication.Responses;

namespace ProductsHub.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    [HttpPost]
    [Route("{clientId}")]
    [ProducesResponseType(typeof(ResponseShortProductJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    public IActionResult Register([FromRoute] Guid clientId, [FromBody] RequestProductJson request)
    {

        var useCase = new RegisterProductUseCase();

        var response = useCase.Execute(clientId, request);

        return Created(string.Empty, response);

    }


    [HttpGet]
    [ProducesResponseType(typeof(ResponseShortProductJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        //var useCase = new GetAllUseCase();

        //var response = useCase.Execute();

        //if (response.Clients.Count == 0)
        //{
        //    return NoContent();
        //}

        return Ok();
    }
}
