using System.Diagnostics.CodeAnalysis;
using Pedidos.Apps.Produtos.Enums;

namespace Pedidos.Adapters.Controllers.Pedidos.Dtos;

[ExcludeFromCodeCoverage]
public record NovoPedidoDto
{
    public Guid PedidoId { get; init; }
    public List<NovoItemDePedido> ItensDoPedido { get; init; } = null!;
}

[ExcludeFromCodeCoverage]
public record NovoItemDePedido
{
    public string Nome { get; init; }
    public ProdutoCategoria Categoria { get; set; }
    public int Quantidade { get; init; }
}