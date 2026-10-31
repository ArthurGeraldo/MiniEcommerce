using MiniEcommerce.Console.Entidades;
using MiniEcommerce.Console.Servicos;

namespace MiniEcommerce.Tests;

public class CarrinhoDeComprasTests
{
    [Fact]
    public void DeveAdicionarProdutoAoCarrinho()
    {
        var produto = new Produto("Mouse", 50, 10);
        var carrinho = new CarrinhoDeCompras();

        carrinho.AdicionarProduto(produto, 2);

        Assert.Single(carrinho.Itens);
        Assert.Equal(2, carrinho.Itens[0].Quantidade);
    }

    [Fact]
    public void DeveCalcularSubtotalCorretamente()
    {
        var produto = new Produto("Mouse", 50, 10);
        var carrinho = new CarrinhoDeCompras();

        carrinho.AdicionarProduto(produto, 2);

        Assert.Equal(100, carrinho.CalcularTotal());
    }

    [Fact]
    public void NaoDeveAdicionarQuantidadeMaiorQueEstoque()
    {
        var produto = new Produto("Mouse", 50, 5);
        var carrinho = new CarrinhoDeCompras();

        Assert.Throws<InvalidOperationException>(() =>
            carrinho.AdicionarProduto(produto, 10));
    }

    [Fact]
    public void NaoDeveAdicionarQuantidadeInvalida()
    {
        var produto = new Produto("Mouse", 50, 10);
        var carrinho = new CarrinhoDeCompras();

        Assert.Throws<ArgumentException>(() =>
            carrinho.AdicionarProduto(produto, 0));
    }

    [Fact]
    public void DeveRemoverProdutoDoCarrinho()
    {
        var produto = new Produto("Mouse", 50, 10);
        var carrinho = new CarrinhoDeCompras();

        carrinho.AdicionarProduto(produto, 2);
        carrinho.RemoverProduto(produto);

        Assert.Empty(carrinho.Itens);
    }
}