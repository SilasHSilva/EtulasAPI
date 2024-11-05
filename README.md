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
         "OracleDb": "User Id=<username>;Password=<password>;Data Source=<datasource>"
       }
     }
     ```

   - Certifique-se de ter o banco de dados e as tabelas criadas conforme necessário.

3. **Executar a Aplicação:**
   - Navegue até o diretório do projeto no terminal.
   - Execute o comando: `dotnet run`
   - A aplicação estará disponível em `http://localhost:5113`.

## Testes Implementados

A API inclui testes abrangentes para garantir sua confiabilidade:

- **Testes Unitários:** Validação das funcionalidades do `HospitalService` e `AuthService`, incluindo o comportamento esperado ao recuperar, adicionar, atualizar e excluir hospitais.
- **Testes de Integração:** Os testes de integração validam os endpoints do `HospitalController`, simulando cenários de requisições reais e verificando o comportamento da API.
- **Testes de Sistema:** Os testes de sistema verificam o funcionamento completo da aplicação, incluindo autenticação via Google e integração com o serviço externo.

Os testes foram implementados utilizando o framework **xUnit**.

## Práticas de Clean Code e SOLID

- **S - Single Responsibility Principle (SRP):** Cada classe tem uma responsabilidade única. Por exemplo, `HospitalService` é responsável pelas operações relacionadas a hospitais, e `AuthService` lida exclusivamente com autenticação.
- **O - Open/Closed Principle (OCP):** As interfaces (`IHospitalService` e `IAuthService`) permitem a expansão de funcionalidades sem modificar a implementação existente.
- **L - Liskov Substitution Principle (LSP):** Interfaces como `IHospitalService` permitem que qualquer implementação futura substitua a atual, respeitando o contrato de métodos assíncronos.
- **I - Interface Segregation Principle (ISP):** Interfaces são definidas para responsabilidades específicas, evitando métodos desnecessários para classes que as implementam.
- **D - Dependency Inversion Principle (DIP):** A injeção de dependência é usada para injetar `HospitalService` e `AuthService`, facilitando a testabilidade e a flexibilidade.

Além dos princípios SOLID, práticas de **Clean Code** foram aplicadas, como nomes de variáveis e métodos que facilitam a compreensão do código e uso de exceções para tratamento de erros.

## Integrantes do Grupo

- Eduardo Bezerra – RM: 98890
- Jefferson Mendes de Farias Lima – RM: 552052
- João Vitor Vicente Benjamin – RM: 98938
- Silas Henrique da Silva Oliveira – RM: 98965

**Observação:** Professor, caso no Swagger não funcione a chamada para o endpoint de autenticação tente pelo `http://localhost:5113/auth/login`. Desde já, agradecemos a atenção.
