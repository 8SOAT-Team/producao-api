using Pedidos.Domain.Exceptions;
using Pedidos.Domain.Pedidos.Entities;
using Pedidos.Domain.Pedidos.Enums;
using Pedidos.Domain.Produtos.Entities;
using Pedidos.Domain.Produtos.Enums;

namespace Pedidos.Tests.UnitTests.Domain.Entities
{
    public class PedidoTest
    {
        [Fact]
        public void DeveCriarNovoPedidoComSucesso()
        {
            //Arrange
            var produto = new Produto("Lanche", "Lanche de bacon", 50m, "http://endereco/imagens/img.jpg", ProdutoCategoria.Acompanhamento);
            var itemPedido = new ItemDoPedido(Guid.NewGuid(), produto, 2);
            List<ItemDoPedido> listaItens = new List<ItemDoPedido>();
            listaItens.Add(itemPedido);
            //Act
            var pedido = new Pedido(Guid.NewGuid(), Guid.NewGuid(), listaItens);
            //Assert
            Assert.NotNull(pedido);
        }

        [Fact]
        public void DeveLancarExceptionQuandoPedidoNaoTiverItens()
        {
            //Arrange
            List<ItemDoPedido> listaItens = new List<ItemDoPedido>();
            //Act
            Action act = () => new Pedido(Guid.NewGuid(), Guid.NewGuid(), listaItens);
            //Assert
            Assert.Throws<DomainExceptionValidation>(() => act());
        }

        [Fact]
        public void DeveLancarExceptionQuandoIdPedidoInvalido()
        {
            //Arrange
            var itemPedido = new ItemDoPedido(Guid.NewGuid(), Guid.NewGuid(), 2);
            List<ItemDoPedido> listaItens = new List<ItemDoPedido>();
            listaItens.Add(itemPedido);
            //Act
            Action act = () => new Pedido(Guid.Empty, Guid.NewGuid(), listaItens);
            //Assert
            Assert.Throws<DomainExceptionValidation>(() => act());
        }

        [Fact]
        public void DeveLancarExceptionQuandoPedidoTiverIdClienteInvalido()
        {
            //Arrange
            var itemPedido = new ItemDoPedido(Guid.NewGuid(), Guid.NewGuid(), 2);
            List<ItemDoPedido> listaItens = new List<ItemDoPedido>();
            listaItens.Add(itemPedido);
            //Act
            Action act = () => new Pedido(Guid.NewGuid(), Guid.Empty, listaItens);
            //Assert
            Assert.Throws<DomainExceptionValidation>(() => act());
        }

        [Fact]
        public void Pedido_DeveCalcularValorTotalCorretamente()
        {
            var pedido = CriarPedidoValido();
            var valorEsperado = pedido.ItensDoPedido.Sum(i => i.Produto.Preco * i.Quantidade);
            Assert.Equal(valorEsperado, pedido.ValorTotal);
        }

        [Fact]
        public void Pedido_DeveLancarExcecao_SeIdInvalido()
        {
            Assert.Throws<DomainExceptionValidation>(() =>
                new Pedido(Guid.Empty, Guid.NewGuid(), CriarItensValidos()));
        }

        [Fact]
        public void Pedido_DeveLancarExcecao_SeClienteIdInvalido()
        {
            Assert.Throws<DomainExceptionValidation>(() =>
                new Pedido(Guid.NewGuid(), Guid.Empty, CriarItensValidos()));
        }

        [Fact]
        public void Pedido_DeveLancarExcecao_SeItensDoPedidoVazio()
        {
            Assert.Throws<DomainExceptionValidation>(() =>
                new Pedido(Guid.NewGuid(), Guid.NewGuid(), new List<ItemDoPedido>()));
        }

        [Fact]
        public void Pedido_IniciarPreparo_DeveAlterarStatusParaEmPreparacao()
        {
            var pedido = CriarPedidoValido();
            pedido.IniciarPreparo();
            Assert.Equal(StatusPedido.EmPreparacao, pedido.StatusPedido);
        }

        [Fact]
        public void Pedido_FinalizarPreparo_DeveAlterarStatusParaPronto()
        {
            var pedido = CriarPedidoValido().IniciarPreparo();
            pedido.FinalizarPreparo();
            Assert.Equal(StatusPedido.Pronto, pedido.StatusPedido);
        }

        [Fact]
        public void Pedido_Entregar_DeveAlterarStatusParaFinalizado()
        {
            var pedido = CriarPedidoValido().IniciarPreparo().FinalizarPreparo();
            pedido.Entregar();
            Assert.Equal(StatusPedido.Finalizado, pedido.StatusPedido);
        }

        [Fact]
        public void Pedido_NaoDeveIniciarPreparo_SeStatusInvalido()
        {
            var pedido = CriarPedidoValido().IniciarPreparo();
            Assert.Throws<DomainExceptionValidation>(() => pedido.IniciarPreparo());
        }

        [Fact]
        public void Pedido_NaoDeveFinalizarPreparo_SeStatusInvalido()
        {
            var pedido = CriarPedidoValido();
            Assert.Throws<DomainExceptionValidation>(() => pedido.FinalizarPreparo());
        }

        [Fact]
        public void Pedido_NaoDeveSerEntregue_SeStatusInvalido()
        {
            var pedido = CriarPedidoValido();
            Assert.Throws<DomainExceptionValidation>(() => pedido.Entregar());
        }

        private Pedido CriarPedidoValido()
        {
            return new Pedido(Guid.NewGuid(), Guid.NewGuid(), CriarItensValidos());
        }

        private List<ItemDoPedido> CriarItensValidos()
        {
            var produto = new Produto("Lanche", "Lanche de bacon", 50m, "http://endereco/imagens/img.jpg", ProdutoCategoria.Acompanhamento);
            return new List<ItemDoPedido>
            {
                new ItemDoPedido(Guid.NewGuid(), produto, 2)
            };
        }
    }
}
