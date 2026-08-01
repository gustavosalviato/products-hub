using ProductsHub.Communication.Responses;
using ProductsHub.Communication.Requests;


namespace ProductsHub.API.UseCases.Clients.Register;

public class RegisterClientUseCase
{
    public ResponseClientJson Execute(ResquestClientJson request) 
    {
        var validator = new RegisterClientValidator();

        var result = validator.Validate(request);


        if (result.IsValid == false)
        {
            throw new ArgumentException("Data error.");
        }

        return new ResponseClientJson();
    }
}
