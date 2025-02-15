using Bogus;
using Pedidos.Domain.Pedidos.Entities;
using Pedidos.Domain.Pedidos.Enums;

namespace Pedidos.Tests.UnitTests.Domain.Stubs.Pedidos;

internal sealed class PedidoStubBuilder : Faker<Pedido>
{
    public PedidoStubBuilder()
    {
        var clienteId = Guid.NewGuid();
        var itensDoPedido = ItemDoPedidoStubBuilder.CreateMany(f => f.Random.Int(1, 5));
        CustomInstantiator(f => new Pedido(Guid.NewGuid(), Guid.NewGuid(), itensDoPedido));
        RuleFor(x => x.ClienteId, clienteId);
    }

    public PedidoStubBuilder WithStatus(StatusPedido status)
    {
        RuleFor(x => x.StatusPedido, status);
        return this;
    }

    public static PedidoStubBuilder NewBuilder() => new();
    public static Pedido Create() => new PedidoStubBuilder().Generate();
    public static List<Pedido> CreateMany(int qty) => new PedidoStubBuilder().Generate(qty);
}