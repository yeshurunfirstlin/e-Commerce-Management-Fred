using e_Commerce.Domain.Contracts;
using e_Commerce.Domain.Entities;
using e_Commerce.Infrastructure.Data;

namespace e_Commerce.Infrastructure.Repositories;

public class ProductRepository(ApplicationDbContext context) : GenericRepository<Product>(context), IProductRepository
{
    public async Task DeleteAsync(int id)
    {
        var _product = await GetByIdAsync(id);
        
        if(_product is not null) context.Products.Remove(_product);
    }
}