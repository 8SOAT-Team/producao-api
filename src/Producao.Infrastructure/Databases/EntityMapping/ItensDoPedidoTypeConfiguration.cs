﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain.Pedidos.Entities;

namespace Pedidos.Infrastructure.Databases.EntityMapping;

public class ItensDoPedidoTypeConfiguration : IEntityTypeConfiguration<ItemDoPedido>
{
    public void Configure(EntityTypeBuilder<ItemDoPedido> builder)
    {
        builder.ToTable("ItensDoPedido");
        builder.HasKey(i => i.Id);
        builder.Property(i => i.ProdutoId).IsRequired();
        builder.Property(i => i.PedidoId).IsRequired();
        builder.HasOne(i => i.Produto).WithMany().HasForeignKey(i => i.ProdutoId);
        builder.HasOne(i => i.Pedido).WithMany(p => p.ItensDoPedido).HasForeignKey(i => i.PedidoId);
    }
}