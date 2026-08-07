using ProductsHub.API.Infrastructure;
using ProductsHub.Exceptions.ExceptionsBase;

namespace ProductsHub.API.UseCases.Products.DeleteProduct
{
    public class DeleteProductUseCase
    {
        public void Execute(Guid productId) 
        {
            var dbContext = new ProductsHubDbContext();

            var product = dbContext.Products.FirstOrDefault(p => p.Id == productId) ?? throw new NotFoundException("Product not found.");

            dbContext.Products.Remove(product);
            dbContext.SaveChanges();
        }
    }
}
