using Pedidos.Adapters.Controllers.Pedidos.Dtos;
using Pedidos.Adapters.Types.Results;
using Pedidos.Domain.Pedidos.Enums;

namespace Pedidos.Adapters.Controllers.Pedidos;

public interface IPedidoController
{
    Task<Result<PedidoDto>> GetPedidoByIdAsync(Guid id);
    Task<Result<PedidoDto>> CreatePedidoAsync(NovoPedidoDto pedido);
    Task<Result<List<PedidoDto>>> GetAllPedidosPending();
    Task<Result<PedidoDto>> FinalizarPreparoPedido(Guid pedidoId);
}