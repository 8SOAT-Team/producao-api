﻿using Pedidos.Domain.Exceptions;
using Pedidos.Domain.Pedidos.Entities;
using Pedidos.Domain.Produtos.Enums;
using Pedidos.Domain.Produtos.ValueObjects;
using TechTalk.SpecFlow;

namespace Pedidos.Tests.BDD.Step;

[Binding]
public class ItemDoPedidoSteps
{
    private ItemDoPedido _itemDoPedido;
    private Produto _produto;
    private Guid _pedidoId;
    private Exception _exception;

    [Given(@"que eu tenha um pedido com ID ""(.*)""")]
    public void DadoQueEuTenhaUmPedidoComID(string pedidoId)
    {
        _pedidoId = Guid.Parse(pedidoId);
    }

    [Given(@"um produto com ID ""(.*)"" e categoria (.*)")]
    public void DadoUmProdutoComIDEPrecoDe(string produtoId, ProdutoCategoria categoria)
    {
        _produto = new Produto("Produto Teste", categoria);
    }

    [Given(@"uma quantidade igual a (.*)")]
    public void DadoUmaQuantidadeIgualA(int quantidade)
    {
        // Verifica se o Produto foi inicializado
        if (_produto == null)
        {
            throw new InvalidOperationException(
                "O Produto não foi inicializado. Certifique-se de configurar o Produto antes de definir a quantidade.");
        }

        // Verifica se o PedidoId foi inicializado
        if (_pedidoId == Guid.Empty)
        {
            throw new InvalidOperationException(
                "O PedidoId não foi inicializado. Certifique-se de configurar o PedidoId antes de definir a quantidade.");
        }

        try
        {
            // Tenta criar o ItemDoPedido com os parâmetros fornecidos
            _itemDoPedido = new ItemDoPedido(_pedidoId, _produto, quantidade);
        }
        catch (DomainExceptionValidation ex)
        {
            // Captura a exceção para validação posterior
            _exception = ex;
        }
    }


    [When(@"eu criar o item do pedido")]
    public void QuandoEuCriarOItemDoPedido()
    {
        Assert.NotNull(_itemDoPedido);
    }

    [Then(@"o item deve ser criado com sucesso")]
    public void EntaoOItemDeveSerCriadoComSucesso()
    {
        Assert.NotNull(_itemDoPedido);
    }

    [Given(@"um produto com ID ""(.*)""")]
    public void DadoUmProdutoComID(string produtoId)
    {
        _produto = new Produto("Produto Teste", ProdutoCategoria.Acompanhamento);
    }

    [When(@"eu tentar criar o item do pedido")]
    public void QuandoEuTentarCriarOItemDoPedido()
    {
        try
        {
            _itemDoPedido = new ItemDoPedido(_pedidoId, _produto, _itemDoPedido.Quantidade);
        }
        catch (Exception ex)
        {
            _exception = ex;
        }
    }

    [Then(@"uma exceção deve ser lançada com a mensagem ""(.*)""")]
    public void EntaoUmaExcecaoDeveSerLancadaComAMensagem(string mensagemEsperada)
    {
        Assert.NotNull(_exception);
        Assert.Contains(mensagemEsperada, _exception.Message);
    }

    [Given(@"que eu tenha um item do pedido com ID ""(.*)"" e quantidade inicial igual a (.*)")]
    public void DadoQueEuTenhaUmItemDoPedidoComIDEQuantidadeInicialIgualA(string itemId, int quantidade)
    {
        _produto = new Produto("Produto Teste", ProdutoCategoria.Acompanhamento);
        _itemDoPedido = new ItemDoPedido(Guid.Parse(itemId), _produto, quantidade);
    }

    [Then(@"o item deve ter uma quantidade total igual a (.*)")]
    public void EntaoOItemDeveTerUmaQuantidadeTotalIgualA(int quantidadeEsperado)
    {
        Assert.Equal(quantidadeEsperado, _itemDoPedido.Quantidade);
    }
}