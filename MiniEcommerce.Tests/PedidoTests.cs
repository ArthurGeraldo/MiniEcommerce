
using MiniEcommerce.Console.Entidades;

namespace MiniEcommerce.Tests;

public class PedidoTests
{
    [Fact]
    public void DeveFinalizarPedidoComSucesso()
    {
        var produto = new Produto("Teclado", 100, 10);
        var item = new ItemCarrinho(produto, 2);

        var pedido = new Pedido(new List<ItemCarrinho> { item });

        Assert.Equal(200, pedido.Total);
        Assert.Equal(8, produto.Estoque);
    }

    [Fact]
    public void DeveCalcularTotalDeVariosProdutos()
    {
        var teclado = new Produto("Teclado", 100, 10);
        var mouse = new Produto("Mouse", 50, 10);

        var itens = new List<ItemCarrinho>
        {
            new ItemCarrinho(teclado, 2),
            new ItemCarrinho(mouse, 1)
        };

        var pedido = new Pedido(itens);

        Assert.Equal(250, pedido.Total);
    }

    [Fact]
    public void NaoDeveFinalizarPedidoComCarrinhoVazio()
    {
        Assert.Throws<InvalidOperationException>(() =>
            new Pedido(new List<ItemCarrinho>()));
    }

    [Fact]
    public void NaoDeveFinalizarPedidoSemEstoque()
    {
        var produto = new Produto("Mouse", 50, 1);
        var item = new ItemCarrinho(produto, 2);

        Assert.Throws<InvalidOperationException>(() =>
            new Pedido(new List<ItemCarrinho> { item }));
    }

    [Fact]
    public void DeveRegistrarDataDoPedido()
    {
        var produto = new Produto("Mouse", 50, 10);
        var item = new ItemCarrinho(produto, 1);

        var pedido = new Pedido(new List<ItemCarrinho> { item });

        Assert.NotEqual(default, pedido.Data);
    }
}
