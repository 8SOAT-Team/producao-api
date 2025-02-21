using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Pedidos.Domain.Pedidos.Entities;

namespace Pedidos.Infrastructure.Databases;
[ExcludeFromCodeCoverage]
public class FastOrderContext : DbContext
{
    public FastOrderContext()
    {
    }

    public FastOrderContext(DbContextOptions<FastOrderContext> options) : base(options)
    {
    }

    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<ItemDoPedido> ItensDoPedido { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FastOrderContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}