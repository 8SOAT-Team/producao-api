using Bogus;
using Pedidos.Api.Dtos;
using Pedidos.Domain.Pedidos.Enums;

namespace Pedidos.Tests.IntegrationTests.Builder;
internal class AtualizarStatusDoPedidoDtoBuilder : Faker<FinalizaPreparoDoPedidoDto>
{
    public AtualizarStatusDoPedidoDtoBuilder()
    {
        CustomInstantiator(f => new FinalizaPreparoDoPedidoDto()
        {
            NovoStatus = StatusPedido.EmPreparacao
        });
    }
    public FinalizaPreparoDoPedidoDto Build() => Generate();
}
