using Pedidos.Adapters.Presenters.Pedidos;
using Pedidos.Domain.Pedidos.Entities;
using Pedidos.Domain.Produtos.Enums;
using Pedidos.Domain.Produtos.ValueObjects;

namespace Pedidos.Tests.UnitTests.Adapters.Presenters.UseCases;
public class PedidoPresenterTests
{
    [Fact]
    public void ToPedidoDto_DeveConverterPedidoParaPedidoDtoCorretamente()
    {
        // Arrange
        var produto = new Produto("Produto Teste", ProdutoCategoria.Bebida);
        var itemDoPedido = new ItemDoPedido(Guid.NewGuid(), produto, 2);
        var pedido = new Pedido(Guid.NewGuid(), new List<ItemDoPedido> { itemDoPedido });

        // Act
        var pedidoDto = PedidoPresenter.ToPedidoDto(pedido);

        // Assert
        Assert.Equal(pedido.Id, pedidoDto.Id);
        Assert.Equal(pedido.DataPedido, pedidoDto.DataPedido);
        Assert.Equal(pedido.StatusPedido, pedidoDto.StatusPedido);      
        Assert.Single(pedidoDto.ItensDoPedido);  
        Assert.Equal(itemDoPedido.Quantidade, pedidoDto.ItensDoPedido.First().Quantidade);
     
    }

    [Fact]
    public void ToListPedidoDto_DeveConverterListaDePedidosParaListaDePedidoDtoCorretamente()
    {
        // Arrange
        var produto = new Produto("Produto Teste", ProdutoCategoria.Bebida);
        var itemDoPedido = new ItemDoPedido(Guid.NewGuid(), produto, 2);
        var pedido = new Pedido(Guid.NewGuid(), new List<ItemDoPedido> { itemDoPedido });
        var pedidos = new List<Pedido> { pedido };

        // Act
        var pedidosDto = PedidoPresenter.ToListPedidoDto(pedidos);

        // Assert
        Assert.Single(pedidosDto);
        Assert.Equal(pedido.Id, pedidosDto[0].Id);
        Assert.Equal(pedido.DataPedido, pedidosDto[0].DataPedido);
        Assert.Equal(pedido.StatusPedido, pedidosDto[0].StatusPedido);        
        Assert.Single(pedidosDto[0].ItensDoPedido);  
        Assert.Equal(itemDoPedido.Quantidade, pedidosDto[0].ItensDoPedido.First().Quantidade);
    
    }
}