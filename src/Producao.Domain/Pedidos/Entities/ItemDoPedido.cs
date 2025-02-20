using System.Text.Json.Serialization;
using Pedidos.Domain.Entities;
using Pedidos.Domain.Exceptions;
using Pedidos.Domain.Produtos.ValueObjects;

namespace Pedidos.Domain.Pedidos.Entities;

public class ItemDoPedido : Entity
{
    protected ItemDoPedido()
    {
    }

    [JsonConstructor]
    public ItemDoPedido(Guid pedidoId, Produto produto, int quantidade)
    {
        ValidateDomain(pedidoId, quantidade);
        PedidoId = pedidoId;
        Produto = produto;
        Quantidade = quantidade;
    }
    public Guid PedidoId { get; init; }
    public virtual Pedido Pedido { get; init; } = null!;
    public virtual Produto Produto { get; set; } = null!;
    public int Quantidade { get; set; }

    private static void ValidateDomain(Guid pedidoId, int quantidade)
    {
        DomainExceptionValidation.When(pedidoId.Equals(Guid.Empty),
            $"Obrigatório informar um {nameof(pedidoId)} válido.");
        DomainExceptionValidation.When(quantidade <= 0,
            $"Obrigatório informar uma {nameof(quantidade)} maior que zero.");
    }
}