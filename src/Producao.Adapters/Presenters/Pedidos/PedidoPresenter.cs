using Pedidos.Adapters.Controllers.Pedidos.Dtos;
using Pedidos.Domain.Pedidos.Entities;
using System.Diagnostics.CodeAnalysis;
using Pedidos.Apps.Produtos.Enums;

namespace Pedidos.Adapters.Presenters.Pedidos;
[ExcludeFromCodeCoverage]
public static class PedidoPresenter
{
    public static PedidoDto ToPedidoDto(this Pedido pedido)
    {
        return new PedidoDto
        {
            Id = pedido.Id,
            DataPedido = pedido.DataPedido,
            StatusPedido = pedido.StatusPedido,
            ItensDoPedido = pedido.ItensDoPedido.Select(p => new ItemDoPedidoDto
            {
                Nome = p.Produto.Nome,
                Categoria = (ProdutoCategoria)p.Produto.Categoria,
                Quantidade = p.Quantidade
            }).ToList(),
        };
    }

    public static List<PedidoDto> ToListPedidoDto(this List<Pedido> pedidos)
    {
        return pedidos.Select(p => p.ToPedidoDto()).ToList();
    }
}