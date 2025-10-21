# 🧱 ProjetoSOLID

**ProjetoSOLID** é uma aplicação de exemplo desenvolvida em **C# .NET 7** com foco em boas práticas de arquitetura de software.  
O projeto implementa os **princípios SOLID**, o **padrão Repository**, o **padrão Unit of Work**, e utiliza **AutoMapper** para o mapeamento entre entidades e DTOs.

---

## 🚀 Tecnologias Utilizadas

- **.NET 7.0**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server**
- **AutoMapper**
- **Dependency Injection**
- **Swagger (Swashbuckle)**
- **DTO Pattern**
- **Repository Pattern**
- **Unit of Work Pattern**
- **SOLID Principles**

---

## 🧩 Estrutura do Projeto

```
src/
├── ProjetoSOLID.Api/                → Camada de apresentação (Controllers, Startup)
├── ProjetoSOLID.Application/        → Camada de aplicação (Serviços, DTOs)
├── ProjetoSOLID.Domain/             → Camada de domínio (Entidades, Interfaces)
├── ProjetoSOLID.Infrastructure/     → Camada de infraestrutura (Repositórios, DbContext, UoW)
```

---

## 🧠 Diagrama de Arquitetura

```text
┌─────────────────────────────┐
│        API (Controllers)    │
│  - Recebe requisições HTTP  │
│  - Retorna respostas JSON   │
└──────────────┬──────────────┘
               │
               ▼
┌─────────────────────────────┐
│      Application Layer      │
│  - Contém serviços e DTOs   │
│  - Usa AutoMapper           │
│  - Orquestra regras via UoW │
└──────────────┬──────────────┘
               │
               ▼
┌─────────────────────────────┐
│         Domain Layer        │
│  - Entidades de negócio     │
│  - Interfaces (contratos)   │
└──────────────┬──────────────┘
               │
               ▼
┌─────────────────────────────┐
│     Infrastructure Layer    │
│  - Implementa repositórios  │
│  - Contexto EF Core (DbCtx) │
│  - Unit of Work             │
└──────────────┬──────────────┘
               │
               ▼
┌─────────────────────────────┐
│         SQL Server          │
│  - Persistência dos dados   │
└─────────────────────────────┘
```

---

## ⚙️ Configuração do Banco de Dados

A conexão com o banco é feita via `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=SEU_SERVIDOR;Database=ProjetoSOLID;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### Criar o banco de dados:

No terminal, execute os comandos:

```bash
cd src/ProjetoSOLID.Api
dotnet ef migrations add InitialCreate -p ../ProjetoSOLID.Infrastructure -s .
dotnet ef database update -p ../ProjetoSOLID.Infrastructure -s .
```

---

## 🧪 Executando o Projeto

Na raiz da solução:

```bash
dotnet run --project src/ProjetoSOLID.Api
```

O Swagger estará disponível em:

👉 [https://localhost:5001/swagger](https://localhost:5001/swagger)

---

## 🧾 Exemplo de Endpoint

### **POST /api/clientes**

**Request Body**
```json
{
  "nome": "Fagner Gonçalves",
  "email": "fagner@email.com"
}
```

**Response**
```json
{
  "id": "4f7b6f8d-1bcd-4f09-b53a-df029ba6b3f3",
  "nome": "Fagner Gonçalves",
  "email": "fagner@email.com"
}
```

---

## 🧱 Padrões e Boas Práticas

O projeto segue:

- **S**: Single Responsibility Principle  
- **O**: Open/Closed Principle  
- **L**: Liskov Substitution Principle  
- **I**: Interface Segregation Principle  
- **D**: Dependency Inversion Principle  

Além de:

- **Repository Pattern** para abstração do acesso a dados  
- **Unit of Work Pattern** para controle transacional  
- **DTOs + AutoMapper** para mapeamento entre entidades e modelos de transporte  
- **Injeção de Dependência (DI)** nativa do .NET  

---

## 🧰 Comandos Úteis

| Ação | Comando |
|------|----------|
| Criar nova migration | `dotnet ef migrations add NomeDaMigration -p ../ProjetoSOLID.Infrastructure -s .` |
| Atualizar banco | `dotnet ef database update -p ../ProjetoSOLID.Infrastructure -s .` |
| Rodar o projeto | `dotnet run --project src/ProjetoSOLID.Api` |
| Restaurar pacotes | `dotnet restore` |
| Compilar a solução | `dotnet build` |

---

## 🧑‍💻 Autor

**Fagner Gonçalves**  
💼 Desenvolvedor Pleno/Sênior .NET  
🚀 Tecnologias: C#, .NET, Entity Framework, SQL Server, SOLID, Clean Code  
