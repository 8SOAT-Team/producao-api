using Bogus;
using Pedidos.Domain.Produtos.Enums;
using Pedidos.Domain.Produtos.ValueObjects;

namespace Pedidos.Tests.UnitTests.Domain.Stubs.Pedidos;

internal sealed class ProdutoStubBuilder : Faker<Produto>
{
    private ProdutoStubBuilder()
    {
        CustomInstantiator(f => new Produto(f.Commerce.ProductName(),f.PickRandom<ProdutoCategoria>()));

     
    }

    public static Produto Create() => new ProdutoStubBuilder().Generate();
    public static List<Produto> CreateMany(int qty) => new ProdutoStubBuilder().Generate(qty);
}