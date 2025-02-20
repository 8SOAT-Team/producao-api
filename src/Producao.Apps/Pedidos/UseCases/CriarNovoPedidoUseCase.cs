using Pedidos.Apps.Pedidos.Gateways;
using Pedidos.Apps.Pedidos.UseCases.Dtos;
using Pedidos.Apps.UseCases;
using Pedidos.Domain.Pedidos.Entities;
using Pedidos.Domain.Produtos.Enums;
using Pedidos.Domain.Produtos.ValueObjects;

namespace Pedidos.Apps.Pedidos.UseCases;

public class CriarNovoPedidoUseCase(
    ILogger<CriarNovoPedidoUseCase> logger,
    IPedidoGateway pedidoGateway) : UseCase<CriarNovoPedidoUseCase, NovoPedidoDto, Pedido>(logger)
{
    protected override async Task<Pedido?> Execute(NovoPedidoDto command)
    {
        var orderItems = command.ItensDoPedido
            .Select(i => MapItemDoPedido(i, command.PedidoId))
            .ToList();

        var pedido = new Pedido(command.PedidoId, orderItems);
        var pedidoEntity = await pedidoGateway.CreateAsync(pedido);

        return pedidoEntity;
    }

    private static ItemDoPedido MapItemDoPedido(ItemDoPedidoDto itemDoPedidoDto, Guid pedidoId)
    {
        return new ItemDoPedido(pedidoId,
            new Produto(itemDoPedidoDto.Nome, (ProdutoCategoria)itemDoPedidoDto.Categoria),
            itemDoPedidoDto.Quantidade);
    }
}