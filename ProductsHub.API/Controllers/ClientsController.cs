using Microsoft.AspNetCore.Mvc;

using ProductsHub.API.UseCases.Clients.Register;
using ProductsHub.Communication.Requests;
using ProductsHub.Communication.Responses;
using ProductsHub.Exceptions.ExceptionsBase;

namespace ProductsHub.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof (ResponseClientJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] ResquestClientJson request)
    {
        try
        {
            var useCase = new RegisterClientUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
        catch (ProductsHubException ex)
        {
            var errors = ex.GetErrors();

            return BadRequest(new ResponseErrorMessagesJson(errors));
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessagesJson("Unknow error."));
        }
    }

    [HttpPut]                                                                       
    public IActionResult Update()
    {
        return Ok();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
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
