using Bogus;
using Pedidos.Adapters.Controllers.Pedidos.Dtos;
using Pedidos.Apps.Pedidos.UseCases.Dtos;

namespace Pedidos.Tests.IntegrationTests.Builder;

internal sealed class NovoPedidoDtoBuilder : Faker<Pedidos.Adapters.Controllers.Pedidos.Dtos.NovoPedidoDto>
{
    public NovoPedidoDtoBuilder()
    {
        RuleFor(p => p.ClienteId, f => f.Random.Guid());
        RuleFor(p => p.ItensDoPedido, f => f.Make(3, () => NovoItemDePedidoBuilder.CreateBuilder().Generate()));
    }

    public NovoPedidoDtoBuilder WithClientId(Guid? clienteId)
    {
        RuleFor(p => p.ClienteId, clienteId);
        return this;
    }

    public NovoPedidoDtoBuilder WithItensDoPedido(
        Func<Faker, NovoItemDePedidoBuilder, List<NovoItemDePedido>> itensDoPedido)
    {
        RuleFor(p => p.ItensDoPedido, f => itensDoPedido(f, NovoItemDePedidoBuilder.CreateBuilder()));
        return this;
    }

    public static NovoPedidoDtoBuilder CreateBuilder() => new();

    public static Pedidos.Adapters.Controllers.Pedidos.Dtos.NovoPedidoDto CreateValid(Func<Faker, NovoItemDePedidoBuilder, List<NovoItemDePedido>> itensDoPedido,
        Guid? clienteId = null)
        => CreateBuilder()
            .WithClientId(clienteId)
            .WithItensDoPedido(itensDoPedido)
            .Generate();

    public static Pedidos.Adapters.Controllers.Pedidos.Dtos.NovoPedidoDto CreateInvalid() => CreateBuilder()
        .WithClientId(Guid.Empty)
    .Generate();
}

internal class NovoPedidoDTOBuilder : Faker<Pedidos.Adapters.Controllers.Pedidos.Dtos.NovoPedidoDto>
{
    public NovoPedidoDTOBuilder()
    {
        CustomInstantiator(f => new Pedidos.Adapters.Controllers.Pedidos.Dtos.NovoPedidoDto()
        {
            ClienteId = f.Random.Guid(),
            ItensDoPedido = new List<NovoItemDePedido>()
            {
                new NovoItemDePedidoBuilder2().Build(),
                new NovoItemDePedidoBuilder2().Build()
            }
        });
    }

    public NovoPedidoDTOBuilder(Guid clienteId)
    {
        CustomInstantiator(f => new Pedidos.Adapters.Controllers.Pedidos.Dtos.NovoPedidoDto()
        {
            ClienteId = clienteId,
            ItensDoPedido = new List<NovoItemDePedido>()
            {
                new NovoItemDePedidoBuilder2().Build(),
                new NovoItemDePedidoBuilder2().Build()
            }
        });
    }

    public Pedidos.Adapters.Controllers.Pedidos.Dtos.NovoPedidoDto Build() => Generate();
}


internal class NovoItemDePedidoBuilder2 : Faker<NovoItemDePedido>
{
    public NovoItemDePedidoBuilder2()
    {
        CustomInstantiator(f => new NovoItemDePedido()
        {
            ProdutoId = RetornaIdProdutoUtil.RetornaIdProduto(),
            Quantidade = f.Random.Int(1, 10)
        });
    }

    public NovoItemDePedido Build() => Generate();
}

public class RetornaIdProdutoUtil
{
    private static List<Guid> produtosId = new List<Guid> { new Guid("0e05db30-b5ec-4e26-b79e-a43b64743ab5"),
    new Guid("f0fdbefb-08b2-4ad7-bdfc-8c3f0e070d8e")};
    public static Guid RetornaIdProduto()
    {

        Random random = new Random();
        int randomIndex = random.Next(produtosId.Count);
        Guid randomId = produtosId[randomIndex];
        return randomId;
    }
}