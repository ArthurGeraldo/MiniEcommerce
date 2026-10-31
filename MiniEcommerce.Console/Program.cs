
using System.Globalization;
using MiniEcommerce.Console.Entidades;
using MiniEcommerce.Console.Servicos;

var catalogo = new Catalogo();
var carrinho = new CarrinhoDeCompras();

bool executando = true;

while (executando)
{
    System.Console.WriteLine("\n===== MINI E-COMMERCE =====");
    System.Console.WriteLine("1 - Cadastrar produto");
    System.Console.WriteLine("2 - Listar catálogo");
    System.Console.WriteLine("3 - Adicionar produto ao carrinho");
    System.Console.WriteLine("4 - Visualizar carrinho");
    System.Console.WriteLine("5 - Remover produto do carrinho");
    System.Console.WriteLine("6 - Finalizar pedido");
    System.Console.WriteLine("0 - Sair");
    System.Console.Write("\nEscolha uma opção: ");

    string? opcao = System.Console.ReadLine();

    try
    {
        switch (opcao)
        {
            case "1":
                CadastrarProduto(catalogo);
                break;

            case "2":
                ListarCatalogo(catalogo);
                break;

            case "3":
                AdicionarAoCarrinho(catalogo, carrinho);
                break;

            case "4":
                VisualizarCarrinho(carrinho);
                break;

            case "5":
                RemoverDoCarrinho(carrinho);
                break;

            case "6":
                FinalizarPedido(carrinho);
                break;

            case "0":
                executando = false;
                System.Console.WriteLine("Sistema encerrado.");
                break;

            default:
                System.Console.WriteLine("Opção inválida.");
                break;
        }
    }
    catch (Exception erro)
    {
        System.Console.WriteLine($"Erro: {erro.Message}");
    }
}

void CadastrarProduto(Catalogo catalogo)
{
    System.Console.Write("\nNome do produto: ");
    string nome = System.Console.ReadLine() ?? "";

    decimal preco = LerPreco();

    int estoque = LerInteiro("Quantidade em estoque: ");

    var produto = new Produto(nome, preco, estoque);

    catalogo.CadastrarProduto(produto);

    System.Console.WriteLine("Produto cadastrado com sucesso!");
}

void ListarCatalogo(Catalogo catalogo)
{
    var produtos = catalogo.ListarProdutos();

    System.Console.WriteLine("\n===== CATÁLOGO =====");

    if (produtos.Count == 0)
    {
        System.Console.WriteLine("Nenhum produto cadastrado.");
        return;
    }

    for (int i = 0; i < produtos.Count; i++)
    {
        var produto = produtos[i];

        System.Console.WriteLine(
            $"{i + 1} - {produto.Nome} | R$ {produto.Preco:F2} | Estoque: {produto.Estoque}");
    }
}

void AdicionarAoCarrinho(Catalogo catalogo, CarrinhoDeCompras carrinho)
{
    var produtos = catalogo.ListarProdutos();

    if (produtos.Count == 0)
    {
        System.Console.WriteLine("Não existem produtos cadastrados.");
        return;
    }

    ListarCatalogo(catalogo);

    int indice = LerInteiro("\nDigite o número do produto: ") - 1;

    if (indice < 0 || indice >= produtos.Count)
    {
        System.Console.WriteLine("Produto inválido.");
        return;
    }

    int quantidade = LerInteiro("Quantidade desejada: ");

    carrinho.AdicionarProduto(produtos[indice], quantidade);

    System.Console.WriteLine("Produto adicionado ao carrinho!");
}

void VisualizarCarrinho(CarrinhoDeCompras carrinho)
{
    System.Console.WriteLine("\n===== CARRINHO =====");

    if (carrinho.Itens.Count == 0)
    {
        System.Console.WriteLine("O carrinho está vazio.");
        return;
    }

    foreach (var item in carrinho.Itens)
    {
        System.Console.WriteLine(
            $"{item.Produto.Nome} | Quantidade: {item.Quantidade} | Subtotal: R$ {item.Subtotal:F2}");
    }

    System.Console.WriteLine($"Total: R$ {carrinho.CalcularTotal():F2}");
}

void RemoverDoCarrinho(CarrinhoDeCompras carrinho)
{
    if (carrinho.Itens.Count == 0)
    {
        System.Console.WriteLine("O carrinho está vazio.");
        return;
    }

    System.Console.WriteLine("\n===== REMOVER PRODUTO =====");

    for (int i = 0; i < carrinho.Itens.Count; i++)
    {
        System.Console.WriteLine(
            $"{i + 1} - {carrinho.Itens[i].Produto.Nome}");
    }

    int indice = LerInteiro("Digite o número do produto que deseja remover: ") - 1;

    if (indice < 0 || indice >= carrinho.Itens.Count)
    {
        System.Console.WriteLine("Opção inválida.");
        return;
    }

    var produto = carrinho.Itens[indice].Produto;

    carrinho.RemoverProduto(produto);

    System.Console.WriteLine("Produto removido do carrinho.");
}

void FinalizarPedido(CarrinhoDeCompras carrinho)
{
    if (carrinho.Itens.Count == 0)
    {
        System.Console.WriteLine("Não é possível finalizar um carrinho vazio.");
        return;
    }

    var pedido = new Pedido(carrinho.Itens);

    System.Console.WriteLine("\n===== PEDIDO FINALIZADO =====");

    foreach (var item in pedido.Itens)
    {
        System.Console.WriteLine(
            $"{item.Produto.Nome} | Quantidade: {item.Quantidade} | R$ {item.Subtotal:F2}");
    }

    System.Console.WriteLine($"Total da compra: R$ {pedido.Total:F2}");
    System.Console.WriteLine($"Data do pedido: {pedido.Data}");

    carrinho.Itens.Clear();

    System.Console.WriteLine("Compra realizada com sucesso!");
}

int LerInteiro(string mensagem)
{
    while (true)
    {
        System.Console.Write(mensagem);

        if (int.TryParse(System.Console.ReadLine(), out int valor))
            return valor;

        System.Console.WriteLine("Digite um número inteiro válido.");
    }
}

decimal LerPreco()
{
    while (true)
    {
        System.Console.Write("Preço do produto: ");

        string entrada = System.Console.ReadLine() ?? "";

        if (decimal.TryParse(
            entrada,
            NumberStyles.Number,
            CultureInfo.GetCultureInfo("pt-BR"),
            out decimal preco))
        {
            return preco;
        }

        System.Console.WriteLine("Digite um preço válido. Exemplo: 19,90");
    }
}
