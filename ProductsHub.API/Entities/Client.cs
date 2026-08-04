namespace ProductsHub.API.Entities;

public class Client
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public String Name { get; set; } = String.Empty;

    public String Email { get; set; } = String.Empty;

}
