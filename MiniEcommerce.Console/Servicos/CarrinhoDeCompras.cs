using MiniEcommerce.Console.Entidades;

namespace MiniEcommerce.Console.Servicos;

public class CarrinhoDeCompras
{
    public List<ItemCarrinho> Itens { get; private set; } = new();

    public void AdicionarProduto(Produto produto, int quantidade)
    {
        if (quantidade <= 0)
            throw new ArgumentException("A quantidade deve ser maior que zero.");

        if (quantidade > produto.Estoque)
            throw new InvalidOperationException("Estoque insuficiente.");

        var itemExistente = Itens.FirstOrDefault(
            item => item.Produto == produto);

        if (itemExistente != null)
        {
            int novaQuantidade = itemExistente.Quantidade + quantidade;

            if (novaQuantidade > produto.Estoque)
                throw new InvalidOperationException("Estoque insuficiente.");

            Itens.Remove(itemExistente);
            Itens.Add(new ItemCarrinho(produto, novaQuantidade));
        }
        else
        {
            Itens.Add(new ItemCarrinho(produto, quantidade));
        }
    }

    public decimal CalcularTotal()
    {
        return Itens.Sum(item => item.Subtotal);
    }

    public void RemoverProduto(Produto produto)
    {
        Itens.RemoveAll(item => item.Produto == produto);
    }
}