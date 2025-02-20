using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain.Pedidos.Entities;

namespace Pedidos.Infrastructure.Databases.EntityMapping;

public class ItensDoPedidoTypeConfiguration : IEntityTypeConfiguration<ItemDoPedido>
{
    public void Configure(EntityTypeBuilder<ItemDoPedido> builder)
    {
        builder.ToTable("ItensDoPedido");
        builder.HasKey(i => i.Id);
        builder.Property(i => i.PedidoId).IsRequired();
        
        builder.OwnsOne(p => p.Produto, produto =>
        {
            produto.Property(p => p.Nome).IsRequired();
            produto.Property(p => p.Categoria).IsRequired();
        });
    }
}