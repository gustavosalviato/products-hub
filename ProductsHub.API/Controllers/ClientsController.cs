using Microsoft.AspNetCore.Mvc;
using ProductsHub.API.UseCases.Clients.Delete;
using ProductsHub.API.UseCases.Clients.GetAll;
using ProductsHub.API.UseCases.Clients.Register;
using ProductsHub.API.UseCases.Clients.Update;
using ProductsHub.Communication.Requests;
using ProductsHub.Communication.Responses;

namespace ProductsHub.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseShortClientJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestClientJson request)
    {

        var useCase = new RegisterClientUseCase();

        var response = useCase.Execute(request);

        return Created(string.Empty, response);

    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    public IActionResult Update([FromRoute] Guid id, [FromBody] RequestClientJson request)
    {
        var useCase = new UpdateClientUseCase();

        useCase.Execute(id, request);

        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseShortClientJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var useCase = new GetAllUseCase();

        var response = useCase.Execute();

        if (response.Clients.Count == 0)
        {
            return NoContent();
        }

        return Ok(response);
    }

    [HttpDelete]
    [Route("{clientId}")]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status204NoContent)]
    public IActionResult Delete([FromRoute] Guid clientId)
    {
        var useCase = new DeleteClientUseCase();

        useCase.Execute(clientId);

        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById([FromRoute] Guid id)                                                                           
    {
        return Ok();
    }
}
