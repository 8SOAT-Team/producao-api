using Pedidos.Apps.Produtos.Enums;

namespace Pedidos.Apps.Pedidos.UseCases.Dtos;

public record ItemDoPedidoDto
{
    public string Nome { get; init; }
    public ProdutoCategoria Categoria { get; set; }
    public int Quantidade { get; init; }
}