using ProductsHub.Communication.Responses;
using ProductsHub.Communication.Requests;
using ProductsHub.Exceptions.ExceptionsBase;


namespace ProductsHub.API.UseCases.Clients.Register;

public class RegisterClientUseCase
{
    public ResponseClientJson Execute(ResquestClientJson request) 
    {
        var validator = new RegisterClientValidator();

        var result = validator.Validate(request);


        if (result.IsValid == false)
        {
            var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errors);
        }

        return new ResponseClientJson();
    }
}
