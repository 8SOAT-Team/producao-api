﻿using System.Diagnostics.CodeAnalysis;

namespace Pedidos.Adapters.Controllers.Pedidos.Dtos;

[ExcludeFromCodeCoverage]
public record NovoPedidoDto
{
    public Guid? ClienteId { get; init; }
    public List<NovoItemDePedido> ItensDoPedido { get; init; } = null!;
}

[ExcludeFromCodeCoverage]
public record NovoItemDePedido
{
    public Guid ProdutoId { get; init; }
    public int Quantidade { get; init; }
}