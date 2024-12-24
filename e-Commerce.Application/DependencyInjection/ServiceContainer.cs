using e_Commerce.Application.Common.AutoMapper;
using e_Commerce.Application.Features.Products.Validation;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace e_Commerce.Application.DependencyInjection;

public static class ServiceContainer
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCategoryCommand).Assembly));
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();
        services.AddAutoMapper(typeof(MapperConfig));

        return services;
    }
}
