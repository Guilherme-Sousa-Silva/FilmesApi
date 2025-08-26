# FilmesApi

API REST para gerenciamento de filmes, desenvolvida em .NET 6, utilizando Entity Framework Core, AutoMapper e Swagger para documentação.

## Tecnologias e Bibliotecas

- [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [Entity Framework Core 6](https://docs.microsoft.com/ef/core/) (`Microsoft.EntityFrameworkCore`, `Microsoft.EntityFrameworkCore.SqlServer`)
- [AutoMapper 12](https://automapper.org/)
- [Swashbuckle.AspNetCore 6](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) (Swagger)
- [Microsoft.Data.SqlClient 5](https://docs.microsoft.com/sql/connect/ado-net/sqlclient-for-sql-server)

## Como utilizar

### 1. Clone o repositório
git clone <[url-do-repositorio](https://github.com/Guilherme-Sousa-Silva/FilmesApi.git)> cd FilmesApi

### 2. Restaure os pacotes
dotnet restore

### 3. Configure a string de conexão
No arquivo `appsettings.json`, configure a string de conexão para o seu SQL Server.

### 4. Execute as migrations (se necessário)
dotnet ef database update

### 5. Execute a aplicação
dotnet run

### 6. Acesse a documentação Swagger

Abra o navegador e acesse:  
`http://localhost:<7009>/swagger`
`http://localhost:<5215>/swagger`

## Endpoints Disponíveis

- `POST /Filme`  
  Adiciona um novo filme.

- `GET /Filme`  
  Retorna a lista de todos os filmes.

- `GET /Filme/{id}`  
  Retorna um filme específico pelo ID.

- `PUT /Filme`  
  Atualiza os dados de um filme existente.

- `DELETE /Filme/{id}`  
  Remove um filme pelo ID.

## Estrutura dos DTOs

- **CreateFilmeDto**: Dados para criação de um filme.
- **ReadFilmeDto**: Dados retornados nas consultas.
- **UpdateFilmeDto**: Dados para atualização de um filme.

## Observações

- O projeto utiliza AutoMapper para conversão entre entidades e DTOs.
- Todas as validações de dados são feitas via Data Annotations.
- A documentação dos endpoints está disponível via Swagger.
- O projeto está configurado para gerar arquivo de documentação XML.

## Requisitos

- .NET 6 SDK
- SQL Server (local ou remoto)

---

Sinta-se à vontade para contribuir ou abrir issues!
