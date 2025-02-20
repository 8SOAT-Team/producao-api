using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain.Pedidos.Entities;
using Pedidos.Domain.Pedidos.Enums;

namespace Pedidos.Infrastructure.Databases.EntityMapping;

internal class PedidoTypeConfiguration : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.ToTable("Pedidos");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.DataPedido).IsRequired();
        builder.Property(p => p.StatusPedido)
            .HasConversion(fromObj => Convert.ToInt32(fromObj), fromDb => (StatusPedido)fromDb);
        builder.HasMany(p => p.ItensDoPedido).WithOne(p => p.Pedido).HasForeignKey(p => p.PedidoId);
    }
}