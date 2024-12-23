using e_Commerce.Domain.Contracts;
using e_Commerce.Infrastructure.Data;
using e_Commerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace e_Commerce.Infrastructure.DependencyInjection;

public static class ServiceContainer
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(o => o.UseSqlite(configuration.GetConnectionString("e-CommerceConnectionString")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>(); 

        return services;
    }
}
