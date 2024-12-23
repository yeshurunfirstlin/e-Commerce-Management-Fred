using e_Commerce.Domain.Entities;

namespace e_Commerce.Domain.Contracts;

public interface IProductRepository
{
    void Add(Product product);
    void Update(Product product);
    Task DeleteAsync(int id);
    Task<Product?> GetByIdAsync(int id);
    Task<IEnumerable<Product>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string name);
}