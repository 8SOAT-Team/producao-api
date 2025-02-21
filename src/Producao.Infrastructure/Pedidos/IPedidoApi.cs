using System.Diagnostics.CodeAnalysis;
using Pedidos.Domain.Pedidos.Enums;
using Refit;

namespace Pedidos.Infrastructure.Pedidos;

[ExcludeFromCodeCoverage]
public record AtualizarStatusDoPedidoDto
{
    public StatusPedido NovoStatus { get; init; }
}

public interface IPedidoApi
{
    [Put("/v1/pedido/{pedidoId}/status")]
    Task<IApiResponse> AtualizaStatusPedido(Guid pedidoId, AtualizarStatusDoPedidoDto request);
}