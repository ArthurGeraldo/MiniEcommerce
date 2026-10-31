using MiniEcommerce.Console.Entidades;

namespace MiniEcommerce.Console.Entidades;

public class ItemCarrinho
{
    public Produto Produto { get; }
    public int Quantidade { get; }

    public decimal Subtotal => Produto.Preco * Quantidade;

    public ItemCarrinho(Produto produto, int quantidade)
    {
        Produto = produto;
        Quantidade = quantidade;
    }
}