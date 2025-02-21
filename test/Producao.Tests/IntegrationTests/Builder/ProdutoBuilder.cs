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
        CustomInstantiator(f => new Produto(f.Name.FullName(), ProdutoCategoria.Sobremesa));
        RuleFor(p => p.Nome, f => f.Commerce.ProductName());
        RuleFor(p => p.Categoria, f => ProdutoCategoria.Sobremesa);
       
    }

    public Produto Build() => Generate();
}
