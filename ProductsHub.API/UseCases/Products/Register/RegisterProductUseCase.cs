using ProductsHub.API.Entities;
using ProductsHub.API.Infrastructure;
using ProductsHub.API.UseCases.Products.SharedValidator;
using ProductsHub.Communication.Requests;
using ProductsHub.Communication.Responses;
using ProductsHub.Exceptions.ExceptionsBase;

namespace ProductsHub.API.UseCases.Products.Register;

public class RegisterProductUseCase
{
    public ResponseShortProductJson Execute(Guid clientId, RequestProductJson request)
    {
        var dbContext = new ProductsHubDbContext();

        Validate(dbContext, clientId, request);


        var entity = new Product
        {
            Name = request.Name,
            Brand = request.Brand,
            Price = request.Price,
            ClientId = clientId
        };


        dbContext.Products.Add(entity);

        dbContext.SaveChanges();

        return new ResponseShortProductJson
        {
            Id = entity.Id,
            Name = request.Name,
            Brand = request.Brand,
            Price = request.Price,
        };

    }

    private void Validate(ProductsHubDbContext dbContext, Guid clientId, RequestProductJson request)
    {
        var clientExists = dbContext.Clients.Any(client => client.Id == clientId);


        if (clientExists == false)
        {
            throw new NotFoundException("Client does not exists");
        }

        var validator = new RequestProductValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errors);
        }
    }
}
