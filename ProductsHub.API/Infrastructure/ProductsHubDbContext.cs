using Microsoft.EntityFrameworkCore;
using ProductsHub.API.Entities;

namespace ProductsHub.API.Infrastructure;

public class ProductsHubDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; } = default!;

    public DbSet<Product> Products { get; set; } = default!;


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\WorkSpace\\DB.db");

    }

}
