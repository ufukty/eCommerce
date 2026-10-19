using Microsoft.EntityFrameworkCore;
using eCommerce.Models;

namespace eCommerce.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<CartItem> CartItems => Set<CartItem>();

    // Optional: protected override void OnModelCreating(ModelBuilder b) { ... }
}