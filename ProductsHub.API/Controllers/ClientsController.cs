using Microsoft.AspNetCore.Mvc;
using ProductsHub.API.UseCases.Clients.GetAll;
using ProductsHub.API.UseCases.Clients.Register;
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
    public IActionResult Register([FromBody] ResquestClientJson request)
    {

        var useCase = new RegisterClientUseCase();

        var response = useCase.Execute(request);

        return Created(string.Empty, response);

    }

    [HttpPut]
    public IActionResult Update()
    {
        return Ok();
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
    public IActionResult Delete()
    {
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        return Ok();
    }
}
