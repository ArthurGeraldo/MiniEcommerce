using MiniEcommerce.Console.Entidades;

namespace MiniEcommerce.Tests;

public class ProdutoTests
{
    [Fact]
    public void DeveCriarProdutoComDadosValidos()
    {
        var produto = new Produto("Teclado", 120, 10);

        Assert.Equal("Teclado", produto.Nome);
        Assert.Equal(120, produto.Preco);
        Assert.Equal(10, produto.Estoque);
    }

    [Fact]
    public void NaoDevePermitirPrecoNegativo()
    {
        Assert.Throws<ArgumentException>(() =>
            new Produto("Teclado", -10, 10));
    }

    [Fact]
    public void NaoDevePermitirEstoqueNegativo()
    {
        Assert.Throws<ArgumentException>(() =>
            new Produto("Teclado", 120, -5));
    }

    [Fact]
    public void NaoDevePermitirNomeVazio()
    {
        Assert.Throws<ArgumentException>(() =>
            new Produto("", 120, 10));
    }
}