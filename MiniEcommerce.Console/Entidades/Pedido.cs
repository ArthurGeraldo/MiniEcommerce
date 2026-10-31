
namespace MiniEcommerce.Console.Entidades;

public class Pedido
{
    public List<ItemCarrinho> Itens { get; }
    public decimal Total { get; }
    public DateTime Data { get; }

    public Pedido(List<ItemCarrinho> itens)
    {
        if (itens == null || itens.Count == 0)
            throw new InvalidOperationException("O carrinho está vazio.");

        Itens = new List<ItemCarrinho>(itens);

        foreach (var item in Itens)
        {
            if (item.Quantidade > item.Produto.Estoque)
                throw new InvalidOperationException("Estoque insuficiente.");
        }

        Total = Itens.Sum(item => item.Subtotal);
        Data = DateTime.Now;

        foreach (var item in Itens)
        {
            item.Produto.BaixarEstoque(item.Quantidade);
        }
    }
}
