using ProductsHub.API.Infrastructure;
using ProductsHub.Communication.Responses;

namespace ProductsHub.API.UseCases.Clients.GetAll;

public class GetAllUseCase
{
    public ResponseAllClientJson Execute()
    {
        var dbContext = new ProductsHubDbContext();


        var clients = dbContext.Clients.ToList();

        return new ResponseAllClientJson
        {
            Clients = clients.Select(client => new ResponseShortClientJson
            {
                Id = client.Id,
                Name = client.Name,
            }).ToList()
        };
    }
}
