using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Pedidos.Adapters.Controllers.Pedidos.Dtos;
using Pedidos.Apps.Produtos.Enums;
using Pedidos.Domain.Pedidos.Entities;
using Pedidos.Tests.IntegrationTests.Builder;
using Pedidos.Tests.IntegrationTests.HostTest;


namespace Pedidos.Tests.IntegrationTests;

public class PedidoEndpointsTest : IClassFixture<FastOrderWebApplicationFactory>
{
    private readonly FastOrderWebApplicationFactory _factory;

    public PedidoEndpointsTest(FastOrderWebApplicationFactory factory)
    {
        _factory = factory;
    }

    private async Task<Pedido> CriarPedido()
    { 
    
        var pedidoExistente = _factory.Context!.Pedidos.FirstOrDefault();
        if (pedidoExistente is null)
        {
            pedidoExistente = new PedidoBuilder().Build();
            _factory.Context.Add(pedidoExistente);
            await _factory.Context.SaveChangesAsync();
        }
       return pedidoExistente;       
    }

    [Fact]
    public async Task POST_Deve_criar_pedido()
    {
        //Arrange      
        var pedido = await CriarPedido();

        var dto = ToNovoPedidoDto(pedido);


        var httpClient = _factory.CreateClient();

        //Act
        var response = await httpClient.PostAsJsonAsync("/v1/pedido", dto);

        //Assert
        response.Should().NotBeNull();
    }

    [Fact]
    public async Task POST_Nao_Deve_Criar_Pedido_Com_Dados_Invalidos()
    {
        //Arrange
        var pedidoDto = NovoPedidoDtoBuilder.CreateInvalid();
        var httpClient = _factory.CreateClient();
        //Act
        var response = await httpClient.PostAsJsonAsync("/v1/pedido", pedidoDto);
        //Assert
        Assert.NotNull(response);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task GET_Deve_Retornar_Pedido_Pelo_Id()
    {
        //Arrange   

        var pedidoExistente = await CriarPedido();

        var httpClient = _factory.CreateClient();
        //Act
        var response = await httpClient.GetAsync($"/v1/pedido/{pedidoExistente.Id}");
        //Assert
        response.Should().NotBeNull();
    }

    [Fact]
    public async Task GET_Deve_Retornar_Todos_Pedidos()
    {
        //Arrange
        const HttpStatusCode expectedStatusCode = HttpStatusCode.OK;
        var clienteId = Guid.NewGuid();


        var pedidoExistente = await CriarPedido();
       
        
        var httpClient = _factory.CreateClient();
        
        //Act
        var response = await httpClient.GetAsync($"/v1/pedido");
        
        //Assert
        response.Should().NotBeNull();
    }
    public static NovoPedidoDto ToNovoPedidoDto(Pedido pedido)
    {
        return new NovoPedidoDto
        {
            ItensDoPedido = pedido.ItensDoPedido.Select(p => new NovoItemDePedido
            {
                Nome = p.Produto.Nome,
                Categoria = (ProdutoCategoria)p.Produto.Categoria,
                Quantidade = p.Quantidade
            }).ToList()
        };
    }
}