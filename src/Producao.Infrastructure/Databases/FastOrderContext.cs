using Microsoft.EntityFrameworkCore;
using Pedidos.Domain.Pedidos.Entities;
using Pedidos.Domain.Produtos.Entities;
using Postech8SOAT.FastOrder.Domain.Entities;

namespace Pedidos.Infrastructure.Databases;

public class FastOrderContext : DbContext
{
    public FastOrderContext()
    {
    }

    public FastOrderContext(DbContextOptions<FastOrderContext> options) : base(options)
    {
    }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<ItemDoPedido> ItensDoPedido { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FastOrderContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}