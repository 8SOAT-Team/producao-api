using Bogus;
using Pedidos.Domain.Produtos.Enums;
using System.Diagnostics.CodeAnalysis;
using Pedidos.Domain.Produtos.ValueObjects;

namespace Pedidos.Tests.IntegrationTests.Builder;
[ExcludeFromCodeCoverage]
public sealed class ProdutoBuilder : Faker<Produto>
{
    public ProdutoBuilder()
    {
        CustomInstantiator(f => new Produto(nome: f.Commerce.ProductName(),
            descricao: f.Commerce.ProductDescription().Substring(0, 30),
            preco: decimal.Parse(f.Commerce.Price(1, 1000)), imagem: f.Image.LoremFlickrUrl()!,
            categoria: f.PickRandom<ProdutoCategoria>()
            ));
    }

    public Produto Build() => Generate();
}