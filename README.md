# Gerenciamento de Produtos
Sistema de gerenciamento de produtos desenvolvido em C# com ASP.NET Core, utilizando Dapper e SQLite.

## Visão Geral
O Gerenciamento de Produtos é uma aplicação para gerenciar informações de produtos, permitindo operações básicas como criar, listar, visualizar detalhes, atualizar e excluir produtos. Utiliza um banco de dados SQLite em memória para armazenamento persistente dos dados.

## Funcionalidades
- **Cadastro de Produtos**: Permite adicionar novos produtos com nome e preço.
- **Listagem de Produtos**: Exibe todos os produtos cadastrados.
- **Listagem de Produto por id**: Mostra informações de um produto específico.
- **Atualização de Produtos**: Permite modificar o nome ou preço de um produto existente.
- **Exclusão de Produtos**: Remove um produto do sistema.
- **Validação de Dados**: Garante que nome e preço sejam fornecidos e válidos antes de salvar no banco de dados.

## Tecnologias Utilizadas
ASP.NET Core: Framework para construção de aplicativos web com C#.
Dapper: Micro ORM que simplifica o acesso a bancos de dados.
SQLite: Banco de dados relacional leve, utilizado em memória para facilitar o desenvolvimento e testes.
Swagger: Ferramenta para documentação e teste de APIs.

## Instalação
Para rodar este projeto localmente, siga os passos abaixo:

1. Clone o repositório:

   ```bash
   git clone https://github.com/Iewandowski/Guarida-Gerenciamento-de-Produtos.git
   
2. Navegue até o diretório do projeto:
    ```bash
   cd .\gerenciamento-de-produto\ 
3. Execute a aplicação:
   ```bash
   dotnet run
4. Para acessar a documentação da API, abra o Swagger:
   ```bash
   http://localhost:5244/swagger/index.html
5. Executar coleção do Postman para testar a API (em anexo no email)
