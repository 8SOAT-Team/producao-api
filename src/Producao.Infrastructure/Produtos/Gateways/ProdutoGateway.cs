using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Pedidos.Apps.Produtos.Enums;
using Pedidos.Apps.Produtos.Gateways.Produtos;
using Pedidos.Domain.Produtos.Entities;
using Pedidos.Infrastructure.Databases;

namespace Pedidos.Infrastructure.Produtos.Gateways;

public class ProdutoGateway : IProdutoGateway
{
    private readonly FastOrderContext _dbContext;
    private readonly DbSet<Produto> _produtos;

    public ProdutoGateway(FastOrderContext dbContext)
    {
        _dbContext = dbContext;
        _produtos = dbContext.Set<Produto>();
    }

    public Task<Produto?> GetProdutoByIdAsync(Guid id)
    {
        const string query = "SELECT * FROM Produtos WHERE id = @id";
        return _produtos.FromSqlRaw(query, new SqlParameter("id", id))
            .FirstOrDefaultAsync();
    }

    public async Task<ICollection<Produto>> ListarProdutosByIdAsync(ICollection<Guid> ids)
    {
        return await _dbContext.Set<Produto>()
            .Where(x => ids.Contains(x.Id))
            .ToListAsync();
    }
    
}