# Mini E-commerce

Projeto desenvolvido em C# com .NET para a disciplina de Garantia da Qualidade de Software.

## Objetivo

Desenvolver um sistema simples de e-commerce executado pelo terminal, permitindo cadastrar produtos, controlar estoque, gerenciar um carrinho de compras e finalizar pedidos.

## Funcionalidades

- Cadastro de produtos com nome, preço e quantidade em estoque.
- Validação de dados dos produtos.
- Listagem do catálogo.
- Adição de produtos ao carrinho.
- Validação de quantidade e disponibilidade em estoque.
- Remoção de produtos do carrinho.
- Cálculo do subtotal e do total da compra.
- Finalização de pedidos.
- Atualização automática do estoque após a compra.

## Tecnologias utilizadas

- C#
- .NET 10
- xUnit
- Git e GitHub

## Estrutura do projeto

```text
MiniEcommerce/
├── MiniEcommerce.sln
├── MiniEcommerce.Console/
│   ├── Program.cs
│   ├── Entidades/
│   │   ├── Produto.cs
│   │   ├── ItemCarrinho.cs
│   │   └── Pedido.cs
│   └── Servicos/
│       ├── Catalogo.cs
│       └── CarrinhoDeCompras.cs
└── MiniEcommerce.Tests/
    ├── ProdutoTests.cs
    ├── CarrinhoDeComprasTests.cs
    └── PedidoTests.cs
```

## Como executar

É necessário ter o SDK do .NET instalado.

Na pasta principal do projeto, execute:

```bash
dotnet test
```

Para iniciar o sistema:

```bash
dotnet run --project MiniEcommerce.Console
```

## Testes

O projeto utiliza xUnit para verificar as regras de negócio, incluindo validação de produtos, operações do carrinho, cálculo de valores e finalização de pedidos.

## Autor

Arthur Geraldo