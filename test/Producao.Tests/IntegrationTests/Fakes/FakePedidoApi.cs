using Pedidos.Infrastructure.Pedidos;
using Refit;

namespace Pedidos.Tests.IntegrationTests.Fakes;

public class FakePedidoApi : IPedidoApi
{
    public Task<IApiResponse> AtualizaStatusPedido(Guid pedidoId, AtualizarStatusDoPedidoDto request)
    {
        return default!;
    }
}