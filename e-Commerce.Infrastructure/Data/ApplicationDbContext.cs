using e_Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_Commerce.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : DbContext(context)
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
}
