using ProductsHub.API.Entities;
using ProductsHub.API.Infrastructure;
using ProductsHub.Communication.Requests;
using ProductsHub.Communication.Responses;
using ProductsHub.Exceptions.ExceptionsBase;


namespace ProductsHub.API.UseCases.Clients.Register;

public class RegisterClientUseCase
{
    public ResponseShortClientJson Execute(ResquestClientJson request)
    {
        Validate(request);


        var dbContext = new ProductsHubDbContext();

        var entity = new Client
        {
            Name = request.Name,
            Email = request.Email
        };

        dbContext.Clients.Add(entity);

        dbContext.SaveChanges();

        return new ResponseShortClientJson 
        { 
            Id = entity.Id,
            Name = entity.Name
        };
    }


    private void Validate(ResquestClientJson request)
    {
        var validator = new RegisterClientValidator();


        var result = validator.Validate(request);


        if (result.IsValid == false)
        {
            var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errors);
        }
    }
}
