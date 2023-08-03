CashFlowTracker

O CashFlowTracker é um sistema de controle de fluxo de caixa diário para comerciantes, permitindo o registro de lançamentos (débitos e créditos) e fornecendo relatórios com o saldo diário consolidado.

Requisitos de Negócio
- Serviço que faz o controle de lançamentos
- Serviço do consolidado diário

Requisitos Técnicos
- Linguagem: C#
- Framework: .NET Core
- Banco de Dados: SQLite
- Padrões de Arquitetura: DDD (Domain-Driven Design)
- Design Patterns: SOLID
- Práticas recomendadas: Boas práticas de programação

Como Executar o Projeto
1. Certifique-se de ter o .NET Core SDK instalado em sua máquina.
2. Clone o repositório para o seu ambiente local.
3. Verifique o arquivo "appsettings.json" na pasta "CashFlowTracker.Web" e ajuste a Connection String para o caminho correto do banco de dados SQLite.
4. Abra um terminal na raiz do projeto "CashFlowTracker.Web".
5. Execute o seguinte comando para criar e aplicar as migrações no banco de dados:

dotnet ef database update

6. Depois, execute o projeto da API com o seguinte comando:

dotnet run --project CashFlowTracker.Web

7. O servidor deve iniciar e você pode acessar a API através do seguinte URL: "https://localhost:5001/".

API Endpoints
Endpoint para lançamentos:
- GET /api/lancamentos: Obter todos os lançamentos.
- POST /api/lancamentos: Criar um novo lançamento.
- GET /api/lancamentos/{id}: Obter um lançamento específico pelo ID.
- PUT /api/lancamentos/{id}: Atualizar um lançamento existente pelo ID.
- DELETE /api/lancamentos/{id}: Excluir um lançamento pelo ID.

Endpoint para consolidação diária:
- GET /api/consolidacao: Obter o saldo consolidado diário.

Projeto MVC para Visualização e Manipulação de Dados
Um projeto MVC está disponível para interagir com a API do CashFlowTracker e realizar o controle de lançamentos e visualizar o saldo consolidado diário. Para executar o projeto MVC, siga os seguintes passos:
1. Verifique o arquivo "appsettings.json" no projeto "CashFlowTracker.MVC" e ajuste a URL da API para o caminho correto da API CashFlowTracker.
2. Abra um terminal na raiz do projeto "CashFlowTracker.MVC".
3. Execute o seguinte comando para iniciar o projeto MVC:

dotnet run --project CashFlowTracker.MVC

4. O servidor deve iniciar e você pode acessar a aplicação web através do seguinte URL: "https://localhost:5001/".

Observações
- Certifique-se de que a API esteja sendo executada antes de iniciar o projeto MVC, pois o projeto MVC depende da API para funcionar corretamente.
- O sistema utiliza o banco de dados SQLite para fins de exemplo. Em um ambiente de produção, você pode configurar outro banco de dados de acordo com as necessidades do seu projeto.

Licença
Este projeto é licenciado sob a Licença MIT - consulte o arquivo LICENSE para obter mais detalhes.
