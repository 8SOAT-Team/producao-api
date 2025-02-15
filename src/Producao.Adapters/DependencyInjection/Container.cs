using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Pedidos.Adapters.Controllers.Pedidos;

namespace Pedidos.Adapters.DependencyInjection;

[ExcludeFromCodeCoverage]
public static class Container
{
    public static IServiceCollection AddUseCaseControllers(this IServiceCollection services)
    {
        services.AddScoped<IPedidoController, PedidoController>();

        return services;
    }
}