using CleanArch.UseCase.Faults;
using Microsoft.Extensions.Logging;
using Moq;
using Pedidos.Apps.Pedidos.Gateways;
using Pedidos.Apps.Pedidos.UseCases;
using Pedidos.Apps.Pedidos.UseCases.Dtos;
using Pedidos.Domain.Pedidos.Entities;
using Pedidos.Domain.Pedidos.Enums;
using Pedidos.Domain.Produtos.Enums;
using Pedidos.Domain.Produtos.ValueObjects;
using Pedidos.Tests.UnitTests.Domain.Stubs.Pedidos;

namespace Pedidos.Tests.UnitTests.Domain.UseCases.Pedidos;

public class FinalizarPreparoPedidoUseCaseTest
{
    private readonly Mock<ILogger<FinalizarPreparoPedidoUseCase>> _loggerMock;
    private readonly Mock<IPedidoGateway> _pedidoGatewayMock;
    private readonly FinalizarPreparoPedidoTest _useCase;

    public FinalizarPreparoPedidoUseCaseTest()
    {
        _loggerMock = new Mock<ILogger<FinalizarPreparoPedidoUseCase>>();
        _pedidoGatewayMock = new Mock<IPedidoGateway>();
        _useCase = new FinalizarPreparoPedidoTest(_loggerMock.Object, _pedidoGatewayMock.Object);
    }

    [Fact]
    public async Task Execute_PedidoNaoEncontrado_ReturnsNullAndAddsError()
    {
        // Arrange
        var pedidoId = Guid.NewGuid();
        var novoStatus = StatusPedido.EmPreparacao;
        var dto = new FinalizarPreparoPedidoDto { PedidoId = pedidoId, NovoStatus = novoStatus };

        _pedidoGatewayMock.Setup(pg => pg.GetByIdAsync(pedidoId)).ReturnsAsync((Pedido?)null);

        // Act
        var result = await _useCase.Execute(dto);

        // Assert
        Assert.Null(result);
        IReadOnlyCollection<UseCaseError> useCaseErrors = _useCase.GetErrors();
        Assert.Single(useCaseErrors);
        Assert.Equal("Pedido não encontrado", useCaseErrors.FirstOrDefault()?.Description);
    }

    [Fact]
    public async Task Execute_StatusInvalido_ReturnsNullAndAddsError()
    {
        // Arrange
        var pedidoId = Guid.NewGuid();
        var novoStatus = (StatusPedido)999;
        var dto = new FinalizarPreparoPedidoDto { PedidoId = pedidoId, NovoStatus = novoStatus };

        var produto = new Produto("Lanche", "Lanche de bacon", 50m, "http://endereco/imagens/img.jpg", ProdutoCategoria.Acompanhamento);
        var itemPedido = new ItemDoPedido(Guid.NewGuid(), produto, 2);
        List<ItemDoPedido> listaItens = new List<ItemDoPedido> { itemPedido };
        var pedido = new Pedido(pedidoId, Guid.NewGuid(), listaItens);

        _pedidoGatewayMock.Setup(pg => pg.GetByIdAsync(pedidoId)).ReturnsAsync(pedido);

        // Act
        var result = await _useCase.Execute(dto);

        // Assert
        Assert.Null(result);
        IReadOnlyCollection<UseCaseError> useCaseErrors = _useCase.GetErrors();
        Assert.Single(useCaseErrors);
        Assert.Equal("Status de pedido inválido", useCaseErrors.FirstOrDefault().Description);
    }


}

public class FinalizarPreparoPedidoTest : FinalizarPreparoPedidoUseCase
{
    public FinalizarPreparoPedidoTest(ILogger<FinalizarPreparoPedidoUseCase> logger, IPedidoGateway pedidoGateway)
        : base(logger, pedidoGateway)
    {
    }

    public new Task<Pedido?> Execute(FinalizarPreparoPedidoDto request)
    {
        return base.Execute(request);
    }
}