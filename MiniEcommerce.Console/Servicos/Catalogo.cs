using MiniEcommerce.Console.Entidades;

namespace MiniEcommerce.Console.Servicos;

public class Catalogo
{
    private List<Produto> produtos = new List<Produto>();

    public void CadastrarProduto(Produto produto)
    {
        produtos.Add(produto);
    }

    public List<Produto> ListarProdutos()
    {
        return produtos;
    }
}