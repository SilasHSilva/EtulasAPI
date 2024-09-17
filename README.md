# API de Gerenciamento de Hospitais

## Arquitetura

**Escolhida:** Monolítica

**Justificativa:** A arquitetura monolítica foi escolhida devido à sua simplicidade de implementação e gerenciamento para projetos menores. Ela evita a complexidade de gerenciar múltiplos serviços independentes e é adequada para aplicações que não precisam de escalabilidade independente de suas partes.

**Diferenças com Microservices:** Em uma arquitetura de microservices, cada funcionalidade (por exemplo, gerenciamento de hospitais, usuários) seria um serviço separado. Isso permitiria escalabilidade e atualizações independentes para cada serviço, aumentando a flexibilidade e a resiliência da aplicação.

## Endpoints Implementados

- **GET /api/Hospitals:** Recupera todos os hospitais.
- **GET /api/Hospitals/{id}:** Recupera um hospital específico por ID.
- **POST /api/Hospitals:** Adiciona um novo hospital.
- **PUT /api/Hospitals/{id}:** Atualiza um hospital existente.
- **DELETE /api/Hospitals/{id}:** Deleta um hospital.

## Padrão de Criação

**Padrão:** Singleton

**Implementação:** O padrão Singleton é utilizado na classe `HospitalService`, garantindo que uma única instância do serviço seja criada e compartilhada em toda a aplicação. Isso ajuda a gerenciar o estado e a configuração de maneira centralizada e evita a criação desnecessária de múltiplas instâncias do serviço.

## Documentação da API

A documentação da API é configurada utilizando Swagger/OpenAPI. Para visualizar a documentação:

1. Execute o projeto.
2. Navegue até [http://localhost:5113/swagger](http://localhost:5113/swagger) em seu navegador.

A documentação inclui descrições claras dos endpoints e modelos de dados.

## Instruções para Rodar a API

1. **Pré-requisitos:**
   - .NET 6.0 ou superior
   - Oracle Database
   - Oracle.ManagedDataAccess.Core (para integração com o banco de dados Oracle)

2. **Configuração:**
   - Configure a conexão com o banco de dados Oracle no arquivo `appsettings.json`:

     ```json
     {
       "ConnectionStrings": {
         "DefaultConnection": "User Id=<username>;Password=<password>;Data Source=<datasource>"
       }
     }
     ```

   - Certifique-se de ter o banco de dados e as tabelas criadas conforme necessário.

3. **Executar a Aplicação:**
   - Navegue até o diretório do projeto no terminal.
   - Execute o comando: `dotnet run`
   - A aplicação estará disponível em `http://localhost:5113`.

## Integrantes do Grupo

- Eduardo Bezerra – RM: 98890
- Jefferson Mendes de Farias Lima – RM: 552052
- João Vitor Vicente Benjamin – RM: 98938
- Silas Henrique da Silva Oliveira – RM: 98965

## Professor espero que reconsidere, pois infelizmente 2 endpoints não funcionaram como deveria, desde ja agradeço