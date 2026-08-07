using ProductsHub.API.Infrastructure;
using ProductsHub.Exceptions.ExceptionsBase;

namespace ProductsHub.API.UseCases.Clients.Delete
{
    public class DeleteClientUseCase
    {
        public void Execute(Guid clientId)
        {
            var dbContext = new ProductsHubDbContext();

            var client = dbContext.Clients.FirstOrDefault(c => c.Id == clientId) ?? throw new NotFoundException("Client not found.");

            dbContext.Clients.Remove(client);
            dbContext.SaveChanges();
        }
    }
}
