﻿using Bogus;
using Pedidos.Domain.Pedidos.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Pedidos.Tests.IntegrationTests.Builder;
[ExcludeFromCodeCoverage]
internal class PedidoBuilder : Faker<Pedido>
{
    public PedidoBuilder()
    {
        CustomInstantiator(f => new Pedido(Guid.NewGuid(), new List<ItemDoPedido>()
            {
                new ItemDoPedidoBuilder().Build(),
                new ItemDoPedidoBuilder().Build()
            }));
    }

    public PedidoBuilder(Guid clientId)
    {
        CustomInstantiator(f => new Pedido(Guid.NewGuid(), new List<ItemDoPedido>()
            {
                new ItemDoPedidoBuilder().Build(),
                new ItemDoPedidoBuilder().Build()
            }));
    }
    public Pedido Build() => Generate();
}
