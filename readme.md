# Desafio Técnico Mercado - Backend

![.NET](https://img.shields.io/badge/.NET-9.0-blueviolet)
![Database](https://img.shields.io/badge/SQL_Server-EC1B24?style=flat&logo=microsoftsqlserver&logoColor=white)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

Este projeto é a implementação de uma API RESTful para um sistema de gerenciamento de produtos de supermercado. O objetivo foi criar um CRUD (Create, Read, Update, Delete) completo, seguindo as regras de negócio especificadas, com uma arquitetura em camadas e boas práticas de desenvolvimento.

O sistema foi desenvolvido como parte de um desafio técnico prático para um processo seletivo que peguei para estudar.

## 📋 Requisitos e Documentação

Os requisitos completos do teste técnico (prova) estão detalhados no documento oficial:
* **[DesafioTecnicoMercado.pdf](https://github.com/marcelogmoura/DesafioTecnicoMercado_back/blob/main/Pdf/DesafioTecnicoMercado.pdf)**


## Funcionalidades

-   ✅ **Cadastro de Produtos:** Permite criar novos produtos com nome, preço, estoque e categoria.
-   ✅ **Listagem de Produtos:** Rota para visualizar todos os produtos cadastrados e seus detalhes.
-   ✅ **Atualização de Produtos:** Permite editar as informações de um produto existente.
-   ✅ **Exclusão de Produtos:** Permite remover um produto, com validação de estoque.
-   ✅ **Documentação da API:** A API é autodocumentada utilizando Swagger (OpenAPI).

## Regras de Negócio Implementadas

O sistema segue as seguintes regras de negócio para garantir a consistência dos dados:

1.  **Nome Único:** Não é permitido cadastrar produtos com o mesmo nome. A validação é feita de forma *case-insensitive*.
2.  **Exclusão com Estoque:** Um produto só pode ser excluído se a sua quantidade em estoque for igual a zero.
3.  **Preço Não Negativo:** O preço de um produto não pode ser um valor negativo.
4.  **Categoria Obrigatória:** É obrigatório associar uma categoria a qualquer produto, tanto no cadastro quanto na edição.

## Tecnologias Utilizadas

-   **.NET 9**: Framework principal para a construção da API.
-   **Entity Framework Core 9**: ORM para a comunicação com o banco de dados.
-   **SQL Server**: Banco de dados relacional para persistência dos dados.
-   **Swagger (Swashbuckle)**: Ferramenta para documentação interativa da API.
-   **FluentValidation**: Biblioteca para criar validações robustas e desacopladas das entidades.
-   **Docker e Docker Compose**: Para containerização da aplicação e do banco de dados.

## Pré-requisitos

-   [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
-   [Docker](https://www.docker.com/products/docker-desktop/) e [Docker Compose](https://docs.docker.com/compose/install/) (para execução via container)
-   Um cliente de API, como [Postman](https://www.postman.com/) ou [Insomnia](https://insomnia.rest/), ou usar a interface do Swagger.

## Como Executar o Projeto

### 1. Usando Docker (Recomendado)

O Docker simplifica a configuração do ambiente, incluindo o banco de dados.

1.  **Clone o repositório:**
    ```bash
    git clone [https://github.com/marcelogmoura/DesafioTecnicoMercado_back.git](https://github.com/marcelogmoura/DesafioTecnicoMercado_back.git)
    cd DesafioTecnicoMercado_back
    ```

2.  **Edite o arquivo `docker-compose.yml` (se necessário):**
    Ajuste a senha do SQL Server na variável de ambiente `SA_PASSWORD` para uma senha mais segura. Lembre-se de atualizar a `ConnectionString` no `appsettings.json` se mudar outros parâmetros.

3.  **Construa e inicie os containers:**
    Este comando irá baixar as imagens, construir a aplicação e iniciar os serviços em background.
    ```bash
    docker-compose up --build -d
    ```

4.  **Acesse a API:**
    A aplicação estará disponível em `http://localhost:5055`.
    A documentação do Swagger pode ser acessada em:
    [http://localhost:5055/swagger/index.html](http://localhost:5055/swagger/index.html)

5.  **Para parar os containers:**
    ```bash
    docker-compose down
    ```

### 2. Rodando Localmente

Para executar o projeto diretamente na sua máquina, sem Docker.

1.  **Clone o repositório.**

2.  **Configure o Banco de Dados:**
    A string de conexão padrão no arquivo `DesafioTecnicoMercado.Infra/Contexts/DataContext.cs` está configurada para usar o LocalDB do SQL Server.
    ```csharp
    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDMercado;Integrated Security=True;");
    ```
    Certifique-se de que você tem o SQL Server ou LocalDB instalado.

3.  **Aplique as Migrations:**
    Navegue até o diretório do projeto de infraestrutura e execute o comando para criar o banco de dados e as tabelas.
    ```bash
    cd DesafioTecnicoMercado.Infra
    dotnet ef database update
    ```

4.  **Execute a API:**
    Volte para a pasta do projeto da API e inicie a aplicação.
    ```bash
    cd ../DesafioTecnicoMercado.API
    dotnet run
    ```

5.  **Acesse a API:**
    A aplicação estará disponível em `http://localhost:5055` e o Swagger em [http://localhost:5055/swagger/index.html](http://localhost:5055/swagger/index.html).

## Estrutura do Projeto

O projeto utiliza uma arquitetura em camadas para separar as responsabilidades:

-   **DesafioTecnicoMercado.Domain**: Contém as entidades de negócio, DTOs (Data Transfer Objects), interfaces de repositórios e serviços, e as validações do FluentValidation.
-   **DesafioTecnicoMercado.Infra**: Camada de acesso a dados, com as implementações dos repositórios usando Entity Framework Core, o `DataContext` e as configurações de mapeamento das tabelas.
-   **DesafioTecnicoMercado.API**: A camada de apresentação, responsável por expor os endpoints da API. Contém os controladores, configuração de injeção de dependência e middleware.

## Endpoints da API

A seguir, a lista de endpoints disponíveis para gerenciar os produtos:

| Verbo  | Rota                  | Descrição                                         |
| :----- | :-------------------- | :------------------------------------------------ |
| `POST` | `/api/Produtos`       | Cadastra um novo produto.                         |
| `GET`  | `/api/Produtos`       | Lista todos os produtos cadastrados.              |
| `GET`  | `/api/Produtos/{id}`  | Obtém os detalhes de um produto específico por ID.|
| `PUT`  | `/api/Produtos/{id}`  | Atualiza as informações de um produto existente.  |
| `DELETE`| `/api/Produtos/{id}`| Exclui um produto (se o estoque for zero).        |


---

👨‍💻 **Autor:** Marcelo Moura 

📧 **Email:** [mgmoura@gmail.com](mailto:mgmoura@gmail.com)   
📧 **Email:** [admin@allriders.com.br](mailto:admin@allriders.com.br)   
🐱 **GitHub:** [github.com/marcelogmoura](https://github.com/marcelogmoura)   
🔗 **LinkedIn:** [linkedin.com/in/marcelogmoura](https://www.linkedin.com/in/marcelogmoura/)   
