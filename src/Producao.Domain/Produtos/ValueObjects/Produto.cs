using System.Text.Json.Serialization;
using Pedidos.Domain.Exceptions;
using Pedidos.Domain.Produtos.Enums;

namespace Pedidos.Domain.Produtos.ValueObjects;

public class Produto
{
    public Produto()
    {
    }



    [JsonConstructor]
    public Produto(string nome, ProdutoCategoria categoria)
    {
        ValidationDomain(nome, categoria);

        Nome = nome;
        Categoria = categoria;
    }

    public string Nome { get; private set; } = null!;
    public ProdutoCategoria Categoria { get; set; }

    private static void ValidationDomain(string nome, ProdutoCategoria categoria)
    {
        ValidateDomainNome(nome);
        ValidateDomainCategoria(categoria);
    }

    private static void ValidateDomainNome(string nome)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome é obrigatório");
    }

    private static void ValidateDomainCategoria(ProdutoCategoria categoria)
    {
        DomainExceptionValidation.When(Enum.IsDefined(categoria) is false, "Id inválido");
    }
}