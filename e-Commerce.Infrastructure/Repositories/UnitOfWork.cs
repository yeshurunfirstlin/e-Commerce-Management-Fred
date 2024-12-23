using e_Commerce.Domain.Contracts;
using e_Commerce.Infrastructure.Data;

namespace e_Commerce.Infrastructure.Repositories;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    public async Task SaveChangesAsync() => await context.SaveChangesAsync();    
}
