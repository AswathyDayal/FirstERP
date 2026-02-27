using FirstERP.Application.Interfaces;
using FirstERP.Application.Services;
using FirstERP.Domain.Interfaces;
using FirstERP.Infrastructure.Data;
using FirstERP.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FirstERP.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<SqlConnectionFactory>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}
