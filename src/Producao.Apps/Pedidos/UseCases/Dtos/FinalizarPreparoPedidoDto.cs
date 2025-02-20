namespace Pedidos.Apps.Pedidos.UseCases.Dtos;

public record FinalizarPreparoPedidoDto
{
    public Guid PedidoId { get; init; }
}