**OrderService** é um microserviço em .NET 7 que recebe pedidos do Sistema A, processa e armazena no banco de dados, permitindo consulta posterior pelo Sistema B. Projetado para alta volumetria (150k–200k pedidos/dia), com foco em consistência, escalabilidade e separação por camadas.

---

## 🧱 Arquitetura

- ✅ ASP.NET Core 7 com Web API
- ✅ Entity Framework Core + SQL Server
- ✅ Clean Architecture (Domain, Application, Infrastructure, API)
- ✅ Repository + Service Pattern
- ✅ DTOs + Validação com Data Annotations
- ✅ Suporte a mensageria (fila de pedidos) via Worker (design opcional)
- ✅ Suporte a escalabilidade horizontal e alta disponibilidade

---

## 📦 Camadas do Projeto

| Projeto                        | Responsabilidade                                       |
|-------------------------------|--------------------------------------------------------|
| `OrderService.Domain`         | Entidades, enums, interfaces de repositórios          |
| `OrderService.Application`    | DTOs, serviços, lógica de negócio                     |
| `OrderService.Infrastructure` | DbContext, Repositórios, configurações EF Core        |
| `OrderService.Api`            | Controllers, Startup, integração externa              |

---

## 📄 Endpoints

### 🔄 Receber pedidos (Sistema A)

http
POST /api/pedido
Exemplo de body:

json
Copy
Edit
{
  "codigoExterno": "ABC-123",
  "produtos": [
    { "nome": "Camisa", "precoUnitario": 50, "quantidade": 2 }
  ]
}
🔍 Consultar pedidos (Sistema B)
http
Copy
Edit
GET /api/pedido           // lista todos
GET /api/pedido/{id}      // busca por ID
GET /api/pedido/{codigoExterno} // busca por código externo (opcional)
⚙️ Setup do projeto
1. Pré-requisitos
.NET 7 SDK

SQL Server local

(Opcional) Docker para mensageria

2. Configurar a connection string
📄 OrderService.Api/appsettings.json

json
Copy
Edit
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=orders_db;Trusted_Connection=True;TrustServerCertificate=True;"
}
3. Criar o banco de dados
bash
Copy
Edit
dotnet ef database update \
  --project OrderService.Infrastructure \
  --startup-project OrderService.Api
4. Rodar a aplicação
bash
Copy
Edit
dotnet run --project OrderService.Api
Acesse: https://localhost:5001/swagger

📌 Pontos de qualidade implementados
✅ Deduplicação via código + índice único no banco

✅ Suporte a alta volumetria com arquitetura assíncrona

✅ Consistência transacional com EF Core

✅ Preparado para background workers e mensageria

✅ Separação clara por camadas e responsabilidades

📈 Futuras melhorias
 Adicionar suporte a RabbitMQ ou Azure Service Bus

 Implementar controle de concorrência otimista com RowVersion

 Implementar cache de leitura com Redis

 Adicionar testes unitários com xUnit + Moq

 Monitoramento com Application Insights

👨‍💻 Autor
Desenvolvido por Thiago Monteiro Barbosa • Projeto técnico demonstrativo para backend em .NET
