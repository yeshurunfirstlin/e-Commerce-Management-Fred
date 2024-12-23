using e_Commerce.Domain.Contracts;
using e_Commerce.Domain.Entities;
using e_Commerce.Infrastructure.Data;

namespace e_Commerce.Infrastructure.Repositories;

public class CategoryRepository(ApplicationDbContext context) : GenericRepository<Category>(context), ICategoryRepository
{
    public void Delete(Category category) => context.Categories.Remove(category);
}
