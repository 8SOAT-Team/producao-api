using Bogus;
using Pedidos.Adapters.Controllers.Pedidos.Dtos;

namespace Pedidos.Tests.IntegrationTests.Builder;
internal sealed class NovoItemDePedidoBuilder : Faker<NovoItemDePedido>
{
    public NovoItemDePedidoBuilder()
    {        
        RuleFor(p => p.Quantidade, f => f.Random.Int(1, 10));
    }
        
    public static NovoItemDePedidoBuilder CreateBuilder() => new();
}
