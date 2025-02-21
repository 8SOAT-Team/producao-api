using Pedidos.Domain.Exceptions;
using Pedidos.Domain.Pedidos.Entities;
using Pedidos.Domain.Produtos.Enums;
using Pedidos.Domain.Produtos.ValueObjects;

namespace Pedidos.Tests.UnitTests.Domain.Entities;
public class ItemDoPedidoTest
{
    [Fact]
    public void DeveCriarNovoItemDoPedidoComSucesso()
    {
        //Act
        var itemPedido = new ItemDoPedido(Guid.NewGuid(), new Produto("Nome", ProdutoCategoria.Acompanhamento), 2);
        //Assert
        Assert.NotNull(itemPedido);
    }

    [Fact]
    public void DeveLancarExceptionAoCriarNovoItemDoPedidoSemQuantidade()
    {
        //Act
        Action act = () => new ItemDoPedido(Guid.NewGuid(), new Produto("Nome", ProdutoCategoria.Acompanhamento), 0);
        //Assert
        Assert.Throws<DomainExceptionValidation>(() => act());
    }

 
  
}