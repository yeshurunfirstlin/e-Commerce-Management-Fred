using e_Commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace e_Commerce.Infrastructure.Repositories;

public abstract class GenericRepository<T>(ApplicationDbContext context) where T : class
{
    public async Task<IEnumerable<T>> GetAllAsync() => await context.Set<T>().AsNoTracking().ToListAsync();
    public async Task<T?> GetByIdAsync(int id) => await context.Set<T>().FindAsync(id);
    public void Add(T entity) => context.Add(entity);
    public void Update(T entity) => context.Update(entity);
    public async Task<bool> IsAvailableByNameAsync(string name)
    {
        var _item = await context.Set<T>().FirstOrDefaultAsync(x => EF.Property<string>(x, "Name") == name);

        return _item != null;
    }
}
