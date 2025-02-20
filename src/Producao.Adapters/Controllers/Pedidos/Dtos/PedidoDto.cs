using Pedidos.Domain.Pedidos.Enums;
using System.Diagnostics.CodeAnalysis;

namespace Pedidos.Adapters.Controllers.Pedidos.Dtos;

[ExcludeFromCodeCoverage]
public record PedidoDto
{
    public Guid Id { get; init; }
    public DateTime DataPedido { get; init; }
    public StatusPedido StatusPedido { get; init; }
    public virtual IReadOnlyCollection<ItemDoPedidoDto> ItensDoPedido { get; init; } = Array.Empty<ItemDoPedidoDto>();
}