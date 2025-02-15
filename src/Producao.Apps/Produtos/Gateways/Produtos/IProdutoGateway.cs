using Pedidos.Apps.Produtos.Enums;
using Pedidos.Domain.Produtos.Entities;

namespace Pedidos.Apps.Produtos.Gateways.Produtos;

public interface IProdutoGateway
{
    Task<Produto?> GetProdutoByIdAsync(Guid id);
    Task<ICollection<Produto>> ListarProdutosByIdAsync(ICollection<Guid> ids);
}