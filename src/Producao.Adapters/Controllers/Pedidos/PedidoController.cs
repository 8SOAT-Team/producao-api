using CleanArch.UseCase.Options;
using Microsoft.Extensions.Logging;
using Pedidos.Adapters.Controllers.Pedidos.Dtos;
using Pedidos.Adapters.Presenters.Pedidos;
using Pedidos.Adapters.Types.Results;
using Pedidos.Apps.Pedidos.Gateways;
using Pedidos.Apps.Pedidos.UseCases;
using Pedidos.Apps.Pedidos.UseCases.Dtos;
using Pedidos.Domain.Pedidos.Entities;
using NovoPedidoDto = Pedidos.Adapters.Controllers.Pedidos.Dtos.NovoPedidoDto;
using NovoPedido = Pedidos.Apps.Pedidos.UseCases.Dtos.NovoPedidoDto;
using ItemDoPedido = Pedidos.Apps.Pedidos.UseCases.Dtos.ItemDoPedidoDto;
using System.Diagnostics.CodeAnalysis;

namespace Pedidos.Adapters.Controllers.Pedidos;
[ExcludeFromCodeCoverage]
public class PedidoController(
    ILoggerFactory logger,
    IPedidoGateway pedidoGateway) : IPedidoController
{
    public async Task<Result<PedidoDto>> FinalizarPreparoPedido(Guid pedidoId)
    {
        var useCase =
            new FinalizarPreparoPedidoUseCase(logger.CreateLogger<FinalizarPreparoPedidoUseCase>(),
                pedidoGateway);
        var useCaseResult = await useCase.ResolveAsync(new FinalizarPreparoPedidoDto
        {
            PedidoId = pedidoId
        });

        return ControllerResultBuilder<PedidoDto, Pedido>
            .ForUseCase(useCase)
            .WithInstance(pedidoId)
            .WithResult(useCaseResult)
            .AdaptUsing(PedidoPresenter.ToPedidoDto)
            .Build();
    }

    public async Task<Result<PedidoDto>> CreatePedidoAsync(NovoPedidoDto pedido)
    {
        var useCase = new CriarNovoPedidoUseCase(logger.CreateLogger<CriarNovoPedidoUseCase>(), pedidoGateway);
        var useCaseResult = await useCase.ResolveAsync(new NovoPedido
        {
            PedidoId = pedido.PedidoId,
            ItensDoPedido = pedido.ItensDoPedido.Select(i => new ItemDoPedido
            {
                Nome = i.Nome,
                Categoria = i.Categoria,
                Quantidade = i.Quantidade
            }).ToList()
        });

        return ControllerResultBuilder<PedidoDto, Pedido>
            .ForUseCase(useCase)
            .WithResult(useCaseResult)
            .AdaptUsing(PedidoPresenter.ToPedidoDto)
            .Build();
    }

    public async Task<Result<List<PedidoDto>>> GetAllPedidosPending()
    {
        var useCase = new ObterListaPedidosPendentesUseCase(logger.CreateLogger<ObterListaPedidosPendentesUseCase>(),
            pedidoGateway);
        var useCaseResult = await useCase.ResolveAsync(Any<object>.Empty);

        return ControllerResultBuilder<List<PedidoDto>, List<Pedido>>
            .ForUseCase(useCase)
            .WithResult(useCaseResult)
            .AdaptUsing(PedidoPresenter.ToListPedidoDto)
            .Build();
    }

    public async Task<Result<PedidoDto>> GetPedidoByIdAsync(Guid id)
    {
        var useCase =
            new EncontrarPedidoPorIdUseCase(logger.CreateLogger<EncontrarPedidoPorIdUseCase>(), pedidoGateway);
        var useCaseResult = await useCase.ResolveAsync(id);

        return ControllerResultBuilder<PedidoDto, Pedido>
            .ForUseCase(useCase)
            .WithResult(useCaseResult)
            .AdaptUsing(PedidoPresenter.ToPedidoDto)
            .Build();
    }
}