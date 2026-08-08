namespace ProductsHub.API.Entities;

public class Product : EntityBase
{
    public String Name { get; set; } = String.Empty;
    public String Brand { get; set; } = String.Empty;
    public Decimal Price { get; set; }
    public Guid ClientId { get; set; }

}
