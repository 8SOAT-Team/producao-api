using Pedidos.Apps.Pedidos.Gateways;
using Pedidos.Infrastructure.Pedidos.Gateways;
using Pedidos.Infrastructure.Requests;

namespace Pedidos.Infrastructure.DependencyInjection;

public static class GatewayService
{
    public static IServiceCollection AddGateways(this IServiceCollection services)
    {
        services.AddScoped<IPedidoGateway, PedidoGateway>();
        services.AddSingleton<IRequestGateway, RequestGateway>();

        return services;
    }
}