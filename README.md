# CRUD MongoDB de Carros - Entrega Lucca Raphael - RM99675

## Objetivo do Projeto

Este projeto é uma aplicação web desenvolvida em ASP.NET Core, que permite a criação, leitura, atualização e exclusão (CRUD) de informações sobre carros utilizando o MongoDB como banco de dados. A aplicação oferece uma interface simples para gerenciar dados de carros, incluindo fabricante, nome e tipo.

## Estrutura do Projeto

- **Controllers**: Contém a lógica de controle para gerenciar as requisições.
  - `CarrosController.cs`: Controlador responsável pela gestão de carros.
  - `HomeController.cs`: Controlador para a página inicial e de privacidade.
  
- **Models**: Define as entidades da aplicação.
  - `Carro.cs`: Modelo representando um carro.
  - `CarroContexto.cs`: Contexto de dados que interage com o MongoDB.
  - `ConfigDB.cs`: Configurações do banco de dados.

- **Views**: Contém as páginas da aplicação.
  - `NovoCarro.cshtml`: Formulário para adicionar um novo carro.
  - `AtualizarCarro.cshtml`: Formulário para editar um carro existente.
  
- **Configurações**: Configurações do MongoDB e da aplicação.

## Requisitos

- .NET 8.0 ou superior
- MongoDB

## Como Rodar o Projeto

### 1. Clonar o Repositório

Clone o repositório para sua máquina local:

```bash
git clone https://github.com/LuccaRaphael/CP5---CARROS.git
cd CP5---CARROS
```

### 2. Configurar o MongoDB

Certifique-se de que o MongoDB está instalado e em execução na sua máquina. A aplicação está configurada para se conectar ao MongoDB em `mongodb://localhost`, utilizando o banco de dados `TestDB`. Você pode modificar essas configurações no arquivo de configuração.

### 3. Restaurar Dependências

Execute o seguinte comando para restaurar as dependências do projeto:

```bash
dotnet restore
```

### 4. Executar o Projeto

Para rodar a aplicação, utilize o comando:

```bash
dotnet run
```

A aplicação estará disponível em `http://localhost:5043`.

### 5. Acessar a Aplicação

Abra um navegador e acesse a URL:

```
http://localhost:5043
```

Você verá a página inicial da aplicação. A partir daqui, você pode acessar as funcionalidades de CRUD para gerenciar os carros.

## Rotas Principais

- **/Carros**: Lista todos os carros cadastrados.
- **/Carros/NovoCarro**: Formulário para adicionar um novo carro.
- **/Carros/AtualizarCarro/{carroId}**: Formulário para editar um carro existente.
- **/Carros/ExcluirCarro/{carroId}**: Rota para excluir um carro.

## Testes

Os testes unitários estão implementados usando xUnit e podem ser executados com o seguinte comando:

```bash
dotnet test
```

