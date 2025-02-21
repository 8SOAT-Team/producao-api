using System.Diagnostics.CodeAnalysis;
using Pedidos.Apps.Pedidos.Gateways;
using Pedidos.CrossCutting;
using Pedidos.Infrastructure.Pedidos;
using Pedidos.Infrastructure.Pedidos.Gateways;
using Pedidos.Infrastructure.Requests;
using Refit;

namespace Pedidos.Infrastructure.DependencyInjection;

[ExcludeFromCodeCoverage]
public static class GatewayService
{
    public static IServiceCollection AddGateways(this IServiceCollection services)
    {
        services.AddScoped<IPedidoGateway, PedidoGateway>();
        services.AddSingleton<IRequestGateway, RequestGateway>();


        services.AddRefitClient<IPedidoApi>()
            .ConfigureHttpClient(client => client.BaseAddress = new Uri(EnvConfig.PedidosApiUrl));
        
        return services;
    }
}