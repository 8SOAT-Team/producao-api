﻿using Pedidos.Domain.Pedidos.Entities;

namespace Pedidos.Apps.Pedidos.Gateways;

public interface IPedidoGateway
{
    Task<Pedido?> GetByIdAsync(Guid id);
    Task<Pedido> CreateAsync(Pedido pedido);
    Task<Pedido> UpdateAsync(Pedido pedido);
    Task<List<Pedido>> GetAllPedidosPending();
    Task<Pedido?> GetPedidoCompletoAsync(Guid id);
    Task AtualizaApiPedidoPronto(Guid pedidoId);
}