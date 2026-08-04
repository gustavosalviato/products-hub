using ProductsHub.API.Infrastructure;
using ProductsHub.API.UseCases.Clients.SharedValidator;
using ProductsHub.Communication.Requests;
using ProductsHub.Exceptions.ExceptionsBase;

namespace ProductsHub.API.UseCases.Clients.Update;

public class UpdateClientUseCase
{
    public void Execute(Guid clientId, RequestClientJson request)
    {
        Validate(request);

        var dbContext = new ProductsHubDbContext();

        var client = dbContext.Clients.FirstOrDefault(x => x.Id == clientId);


        if (client is null) 
        {
            throw new NotFoundException("Client not found.");
        }


        client.Name = request.Name;
        client.Email = request.Email;

        dbContext.Clients.Update(client);
        dbContext.SaveChanges();
    }


    private void Validate(RequestClientJson request)
    {
        var validator = new RequestClientValidator();


        var result = validator.Validate(request);


        if (result.IsValid == false)
        {
            var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errors);
        }
    }
}
