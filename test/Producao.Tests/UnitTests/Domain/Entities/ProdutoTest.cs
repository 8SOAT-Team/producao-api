using Bogus;
using Pedidos.Domain.Exceptions;
using Pedidos.Domain.Produtos.Enums;
using Pedidos.Domain.Produtos.ValueObjects;

namespace Pedidos.Tests.UnitTests.Domain.Entities;
public class ProdutoTest
{
    private readonly Faker _faker = new();
    
    [Fact]
    public void DeveRetornarExceptionQuandoNomeForNulo()
    {
        //Arrange
        var nome = "";
        var descricao = "Teste";
        //Act
        Action act = () => new Produto(nome, _faker.PickRandom<ProdutoCategoria>());
        //Assert
        Assert.Throws<DomainExceptionValidation>(() => act());
    }
    

    [Fact]
    public void DeveCriarProdutoComSucesso()
    {
        //Arrange
        var nome = "Teste";
        var descricao = "Teste";
        //Act
        var produto = new Produto(nome, _faker.PickRandom<ProdutoCategoria>());
        //Assert
        Assert.NotNull(produto);
    }

    [Theory]
    [InlineData("Teste",  ProdutoCategoria.Lanche)]
    [InlineData("Teste2", ProdutoCategoria.Lanche)]
    [InlineData("Teste3", ProdutoCategoria.Lanche)]
    public void DeveCriarProdutoComSucessoParametrizado(string nome,ProdutoCategoria categoria)
    {
        //Arrange
        //Act
        var produto = new Produto(nome, categoria);
        //Assert
        Assert.NotNull(produto);
    }

    

   
}
