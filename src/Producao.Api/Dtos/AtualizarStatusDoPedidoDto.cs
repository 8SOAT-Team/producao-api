using Pedidos.Domain.Pedidos.Enums;
using System.Diagnostics.CodeAnalysis;

namespace Pedidos.Api.Dtos;

[ExcludeFromCodeCoverage]

public record AtualizarStatusDoPedidoDto
{
    public StatusPedido NovoStatus { get; init; }
}