﻿using Pedidos.Apps.Pedidos.Gateways;
using Pedidos.Apps.Produtos.Gateways.Produtos;
using Pedidos.CrossCutting;
using Pedidos.Infrastructure.Pedidos.Gateways;
using Pedidos.Infrastructure.Produtos.Gateways;
using Pedidos.Infrastructure.Requests;

namespace Pedidos.Infrastructure.DependencyInjection;

public static class GatewayService
{
    public static IServiceCollection AddGateways(this IServiceCollection services)
    {

        services.AddScoped<IProdutoGateway, ProdutoGateway>()
            .DecorateIf<IProdutoGateway, ProdutoGatewayCache>(() => !EnvConfig.IsTestEnv);

        services.AddScoped<IPedidoGateway, PedidoGateway>()
            .DecorateIf<IPedidoGateway, PedidoGatewayCache>(() => !EnvConfig.IsTestEnv);

        services.AddSingleton<IRequestGateway, RequestGateway>();

        return services;
    }
}