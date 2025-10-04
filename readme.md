# Desafio T�cnico Mercado - Backend

Este projeto � a implementa��o de uma API RESTful para um sistema de gerenciamento de produtos de supermercado. O objetivo foi criar um CRUD (Create, Read, Update, Delete) completo, seguindo as regras de neg�cio especificadas, com uma arquitetura em camadas e boas pr�ticas de desenvolvimento.

O sistema foi desenvolvido como parte de um desafio t�cnico pr�tico para um processo seletivo.

## Funcionalidades

-   ? **Cadastro de Produtos:** Permite criar novos produtos com nome, pre�o, estoque e categoria.
-   ? **Listagem de Produtos:** Rota para visualizar todos os produtos cadastrados e seus detalhes.
-   ? **Atualiza��o de Produtos:** Permite editar as informa��es de um produto existente.
-   ? **Exclus�o de Produtos:** Permite remover um produto, com valida��o de estoque.
-   ? **Documenta��o da API:** A API � autodocumentada utilizando Swagger (OpenAPI).

## Regras de Neg�cio Implementadas

O sistema segue as seguintes regras de neg�cio para garantir a consist�ncia dos dados:

1.  **Nome �nico:** N�o � permitido cadastrar produtos com o mesmo nome. A valida��o � feita de forma *case-insensitive*.
2.  **Exclus�o com Estoque:** Um produto s� pode ser exclu�do se a sua quantidade em estoque for igual a zero.
3.  **Pre�o N�o Negativo:** O pre�o de um produto n�o pode ser um valor negativo.
4.  **Categoria Obrigat�ria:** � obrigat�rio associar uma categoria a qualquer produto, tanto no cadastro quanto na edi��o.

## Tecnologias Utilizadas

-   **.NET 9**: Framework principal para a constru��o da API.
-   **Entity Framework Core 9**: ORM para a comunica��o com o banco de dados.
-   **SQL Server**: Banco de dados relacional para persist�ncia dos dados.
-   **Swagger (Swashbuckle)**: Ferramenta para documenta��o interativa da API.
-   **FluentValidation**: Biblioteca para criar valida��es robustas e desacopladas das entidades.
-   **Docker e Docker Compose**: Para containeriza��o da aplica��o e do banco de dados.

## Pr�-requisitos

-   [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
-   [Docker](https://www.docker.com/products/docker-desktop/) e [Docker Compose](https://docs.docker.com/compose/install/) (para execu��o via container)
-   Um cliente de API, como [Postman](https://www.postman.com/) ou [Insomnia](https://insomnia.rest/), ou usar a interface do Swagger.

## Como Executar o Projeto

### 1. Usando Docker (Recomendado)

O Docker simplifica a configura��o do ambiente, incluindo o banco de dados.

1.  **Clone o reposit�rio:**
    ```bash
    git clone [https://github.com/seu-usuario/DesafioTecnicoMercado_back.git](https://github.com/seu-usuario/DesafioTecnicoMercado_back.git)
    cd DesafioTecnicoMercado_back
    ```

2.  **Edite o arquivo `docker-compose.yml` (se necess�rio):**
    Ajuste a senha do SQL Server na vari�vel de ambiente `SA_PASSWORD` para uma senha mais segura. Lembre-se de atualizar a `ConnectionString` no `appsettings.json` se mudar outros par�metros.

3.  **Construa e inicie os containers:**
    Este comando ir� baixar as imagens, construir a aplica��o e iniciar os servi�os em background.
    ```bash
    docker-compose up --build -d
    ```

4.  **Acesse a API:**
    A aplica��o estar� dispon�vel em `http://localhost:5055`.
    A documenta��o do Swagger pode ser acessada em:
    [http://localhost:5055/swagger/index.html](http://localhost:5055/swagger/index.html)

5.  **Para parar os containers:**
    ```bash
    docker-compose down
    ```

### 2. Rodando Localmente

Para executar o projeto diretamente na sua m�quina, sem Docker.

1.  **Clone o reposit�rio:** (mesmo passo anterior)

2.  **Configure o Banco de Dados:**
    A string de conex�o padr�o no arquivo `DesafioTecnicoMercado.Infra/Contexts/DataContext.cs` est� configurada para usar o LocalDB do SQL Server.
    ```csharp
    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDMercado;Integrated Security=True;");
    ```
    Certifique-se de que voc� tem o SQL Server ou LocalDB instalado.

3.  **Aplique as Migrations:**
    Navegue at� o diret�rio do projeto de infraestrutura e execute o comando para criar o banco de dados e as tabelas.
    ```bash
    cd DesafioTecnicoMercado.Infra
    dotnet ef database update
    ```

4.  **Execute a API:**
    Volte para a pasta do projeto da API e inicie a aplica��o.
    ```bash
    cd ../DesafioTecnicoMercado.API
    dotnet run
    ```

5.  **Acesse a API:**
    A aplica��o estar� dispon�vel em `http://localhost:5055` e o Swagger em [http://localhost:5055/swagger/index.html](http://localhost:5055/swagger/index.html).

## Estrutura do Projeto

O projeto utiliza uma arquitetura em camadas para separar as responsabilidades:

-   ?? **`DesafioTecnicoMercado.Domain`**: Cont�m as entidades de neg�cio, DTOs (Data Transfer Objects), interfaces de reposit�rios e servi�os, e as valida��es do FluentValidation.
-   ?? **`DesafioTecnicoMercado.Infra`**: Camada de acesso a dados, com as implementa��es dos reposit�rios usando Entity Framework Core, o `DataContext` e as configura��es de mapeamento das tabelas.
-   ?? **`DesafioTecnicoMercado.API`**: A camada de apresenta��o, respons�vel por expor os endpoints da API. Cont�m os controladores, configura��o de inje��o de depend�ncia e middleware.

## Endpoints da API

A seguir, a lista de endpoints dispon�veis para gerenciar os produtos:

| Verbo  | Rota                  | Descri��o                                         |
| :----- | :-------------------- | :------------------------------------------------ |
| `POST` | `/api/Produtos`       | Cadastra um novo produto.                         |
| `GET`  | `/api/Produtos`       | Lista todos os produtos cadastrados.              |
| `GET`  | `/api/Produtos/{id}`  | Obt�m os detalhes de um produto espec�fico por ID.|
| `PUT`  | `/api/Produtos/{id}`  | Atualiza as informa��es de um produto existente.  |
| `DELETE`| `/api/Produtos/{id}`| Exclui um produto (se o estoque for zero).        |


????? **Autor:** Marcelo Moura 

?? **Email:** [mgmoura@gmail.com](mailto:mgmoura@gmail.com)   
?? **Email:** [admin@allriders.com.br](mailto:admin@allriders.com.br)   

?? **GitHub:** [github.com/marcelogmoura](https://github.com/marcelogmoura)   
