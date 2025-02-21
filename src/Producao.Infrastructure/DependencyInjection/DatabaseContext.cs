using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Pedidos.CrossCutting;
using Pedidos.Infrastructure.Databases;

namespace Pedidos.Infrastructure.DependencyInjection;
[ExcludeFromCodeCoverage]
public static class DatabaseContext
{
    public static IServiceCollection AddDatabaseContext(this IServiceCollection services)
    {
        services.AddDbContext<FastOrderContext>(options =>
            options.UseLazyLoadingProxies().UseSqlServer(EnvConfig.DatabaseConnection));

        return services;
    }
}