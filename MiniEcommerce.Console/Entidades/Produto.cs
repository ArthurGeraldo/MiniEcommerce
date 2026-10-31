
namespace MiniEcommerce.Console.Entidades;

public class Produto
{
    public string Nome { get; private set; }
    public decimal Preco { get; private set; }
    public int Estoque { get; private set; }

    public Produto(string nome, decimal preco, int estoque)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome não pode ser vazio.");

        if (preco < 0)
            throw new ArgumentException("O preço não pode ser negativo.");

        if (estoque < 0)
            throw new ArgumentException("O estoque não pode ser negativo.");

        Nome = nome;
        Preco = preco;
        Estoque = estoque;
    }

    public void BaixarEstoque(int quantidade)
    {
        if (quantidade <= 0)
            throw new ArgumentException("Quantidade inválida.");

        if (quantidade > Estoque)
            throw new InvalidOperationException("Estoque insuficiente.");

        Estoque -= quantidade;
    }
}
