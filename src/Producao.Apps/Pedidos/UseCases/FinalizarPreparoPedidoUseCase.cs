using CleanArch.UseCase.Faults;
using Pedidos.Apps.Pedidos.Gateways;
using Pedidos.Apps.Pedidos.UseCases.Dtos;
using Pedidos.Apps.UseCases;
using Pedidos.Domain.Pedidos.Entities;

namespace Pedidos.Apps.Pedidos.UseCases;

public class
    FinalizarPreparoPedidoUseCase(
        ILogger<FinalizarPreparoPedidoUseCase> logger,
        IPedidoGateway pedidoGateway)
    : UseCase<FinalizarPreparoPedidoUseCase, FinalizarPreparoPedidoDto, Pedido>(logger)
{
    protected override async Task<Pedido?> Execute(FinalizarPreparoPedidoDto request)
    {
        var pedido = await pedidoGateway.GetByIdAsync(request.PedidoId);

        if (pedido is null)
        {
            AddError(new UseCaseError(UseCaseErrorType.BadRequest, "Pedido não encontrado"));
            return null;
        }

        pedido.FinalizarPreparo();

        await pedidoGateway.AtualizaApiPedidoPronto(pedido.Id);
        
        return await pedidoGateway.UpdateAsync(pedido);
    }
}