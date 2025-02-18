﻿using CleanArch.UseCase.Faults;
using Pedidos.Apps.Pedidos.Gateways;
using Pedidos.Apps.Pedidos.UseCases.Dtos;
using Pedidos.Apps.UseCases;
using Pedidos.Domain.Pedidos.Entities;
using Pedidos.Domain.Pedidos.Enums;

namespace Pedidos.Apps.Pedidos.UseCases;

public class
    AtualizarStatusDePreparoPedidoUseCase(
        ILogger<AtualizarStatusDePreparoPedidoUseCase> logger,
        IPedidoGateway pedidoGateway)
    : UseCase<AtualizarStatusDePreparoPedidoUseCase, NovoStatusDePedidoDto, Pedido>(logger)
{
    private static readonly Dictionary<StatusPedido, Func<Pedido, Pedido>> ActionUpdateStatus = new()
    {
        { StatusPedido.Pronto, p => p.FinalizarPreparo() },
        { StatusPedido.Finalizado, p => p.Entregar() }
    };

    protected override async Task<Pedido?> Execute(NovoStatusDePedidoDto request)
    {
        var pedido = await pedidoGateway.GetByIdAsync(request.PedidoId);

        if (pedido is null)
        {
            AddError(new UseCaseError(UseCaseErrorType.BadRequest, "Pedido não encontrado"));
            return null;
        }

        if (!ActionUpdateStatus.TryGetValue(request.NovoStatus, out var action))
        {
            AddError(new UseCaseError(UseCaseErrorType.BadRequest, "Status de pedido inválido"));
            return null;
        }

        _ = action(pedido);
        return await pedidoGateway.UpdateAsync(pedido);
    }
}