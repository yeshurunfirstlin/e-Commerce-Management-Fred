namespace e_Commerce.Domain.Contracts;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}