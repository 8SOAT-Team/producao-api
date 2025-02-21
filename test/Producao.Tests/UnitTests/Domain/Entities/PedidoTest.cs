using Pedidos.Domain.Exceptions;
using Pedidos.Domain.Pedidos.Entities;
using Pedidos.Domain.Pedidos.Enums;
using Pedidos.Domain.Produtos.Enums;
using Pedidos.Domain.Produtos.ValueObjects;

namespace Pedidos.Tests.UnitTests.Domain.Entities
{
    public class PedidoTest
    {
        [Fact]
        public void DeveCriarNovoPedidoComSucesso()
        {
            //Arrange
            var produto = new Produto("Nome", ProdutoCategoria.Acompanhamento);
            var itemPedido = new ItemDoPedido(Guid.NewGuid(), produto, 2);
            List<ItemDoPedido> listaItens = new List<ItemDoPedido>();
            listaItens.Add(itemPedido);
            //Act
            var pedido = new Pedido(Guid.NewGuid(), listaItens);
            //Assert
            Assert.NotNull(pedido);
        }

        [Fact]
        public void DeveLancarExceptionQuandoPedidoNaoTiverItens()
        {
            //Arrange
            List<ItemDoPedido> listaItens = new List<ItemDoPedido>();
            //Act
            Action act = () => new Pedido(Guid.NewGuid(),listaItens);
            //Assert
            Assert.Throws<DomainExceptionValidation>(() => act());
        }

        [Fact]
        public void DeveLancarExceptionQuandoIdPedidoInvalido()
        {
            //Arrange
            var itemPedido = new ItemDoPedido(Guid.NewGuid(), new Produto("Nome", ProdutoCategoria.Acompanhamento), 2);
            List<ItemDoPedido> listaItens = new List<ItemDoPedido>();
            listaItens.Add(itemPedido);
            //Act
            Action act = () => new Pedido(Guid.Empty,listaItens);
            //Assert
            Assert.Throws<DomainExceptionValidation>(() => act());
        }

        

        
        [Fact]
        public void Pedido_DeveLancarExcecao_SeIdInvalido()
        {
            Assert.Throws<DomainExceptionValidation>(() =>
                new Pedido(Guid.Empty, CriarItensValidos()));
        }

        

        [Fact]
        public void Pedido_DeveLancarExcecao_SeItensDoPedidoVazio()
        {
            Assert.Throws<DomainExceptionValidation>(() =>
                new Pedido(Guid.NewGuid(), new List<ItemDoPedido>()));
        }

        [Fact]
        public void Pedido_IniciarPreparo_DeveAlterarStatusParaEmPreparacao()
        {
            var pedido = CriarPedidoValido();
            pedido.FinalizarPreparo();
            Assert.Equal(StatusPedido.Pronto, pedido.StatusPedido);
        }

        [Fact]
        public void Pedido_Entregar_DeveAlterarStatusParaFinalizado()
        {
            var pedido = CriarPedidoValido().FinalizarPreparo();
            
            Assert.Equal(StatusPedido.Pronto, pedido.StatusPedido);
        }

        [Fact]
        public void Pedido_NaoDeveIniciarPreparo_SeStatusInvalido()
        {
            var pedido = CriarPedidoValido().FinalizarPreparo();
            Assert.Throws<DomainExceptionValidation>(() => pedido.FinalizarPreparo());
        }

       
        private Pedido CriarPedidoInValido()
        {
            return new Pedido(new Guid(), new List<ItemDoPedido>());
        }

       

        private Pedido CriarPedidoValido()
        {
            return new Pedido(Guid.NewGuid(), CriarItensValidos());
        }

        private List<ItemDoPedido> CriarItensValidos()
        {
            var produto = new Produto("Nome", ProdutoCategoria.Acompanhamento);
            return new List<ItemDoPedido>
            {
                new ItemDoPedido(Guid.NewGuid(), produto, 2)
            };
        }
    }
}
