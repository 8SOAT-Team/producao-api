using System.Diagnostics.CodeAnalysis;
using Pedidos.Apps.Produtos.Enums;

namespace Pedidos.Adapters.Controllers.Pedidos.Dtos;


[ExcludeFromCodeCoverage]
public record ItemDoPedidoDto
{
    public string Nome { get; init; }
    public string Observacao { get; init; }
    public ProdutoCategoria Categoria { get; set; }
    public int Quantidade { get; init; }
}