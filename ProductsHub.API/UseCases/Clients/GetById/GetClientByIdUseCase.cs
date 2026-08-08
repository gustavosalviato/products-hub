using Microsoft.EntityFrameworkCore;
using ProductsHub.API.Infrastructure;
using ProductsHub.Communication.Responses;
using ProductsHub.Exceptions.ExceptionsBase;

namespace ProductsHub.API.UseCases.Clients.GetById;

public class GetClientByIdUseCase
{
    public ResponseClientJson Execute(Guid clientId)
    {
        var dbContext = new ProductsHubDbContext();

        var entity = dbContext.Clients.Include(client => client.Products).FirstOrDefault(client => client.Id == clientId);

        if (entity is null)
            throw new NotFoundException("Client not found.");


        return new ResponseClientJson
        {
            Id = entity.Id,
            Name = entity.Name,
            Email = entity.Email,
            Products = entity.Products.Select(product => new ResponseShortProductJson
            {
                Id = product.Id,
                Name = product.Name,
                Brand = product.Brand,
                Price = product.Price
            }).ToList()
        };

    }
}
