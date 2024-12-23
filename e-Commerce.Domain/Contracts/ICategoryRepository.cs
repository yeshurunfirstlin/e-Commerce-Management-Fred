using e_Commerce.Domain.Entities;

namespace e_Commerce.Domain.Contracts;

public interface ICategoryRepository
{
    void Add(Category category);
    void Update(Category category);
    void Delete(Category category);
    Task<Category?> GetByIdAsync(int id);
    Task<IEnumerable<Category>> GetAllAsync();
    Task<bool> IsAvailableByNameAsync(string name);
}