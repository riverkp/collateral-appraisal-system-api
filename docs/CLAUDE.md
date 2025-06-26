# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Common Commands

### Development Setup
```bash
# Start infrastructure services (SQL Server, Redis, RabbitMQ, Keycloak, Seq)
docker-compose up -d

# Build the solution
dotnet build

# Run the main API
dotnet run --project Bootstrapper/Api

# Run tests (if any exist)
dotnet test
```

### Database Operations
```bash
# Add new migration for a specific module
dotnet ef migrations add <MigrationName> --project Modules/Request/Request --startup-project Bootstrapper/Api

# Update database
dotnet ef database update --project Modules/Request/Request --startup-project Bootstrapper/Api
```

### Project Structure Commands
```bash
# Build specific module
dotnet build Modules/Request/Request

# Clean and rebuild
dotnet clean && dotnet build
```

## Architecture Overview

### Modular Monolith Design
- **Bootstrapper/Api**: Main entry point and configuration
- **Modules/**: Business domains as separate modules
  - **Request**: Core request management with full CRUD operations
  - **Auth**: Authentication with dual OAuth2/Keycloak support  
  - **Notification**: Event-driven messaging and notifications
  - **Collateral**: Collateral management (minimal implementation)
- **Shared/**: Cross-cutting concerns and infrastructure

### Technology Stack
- **.NET 9.0** with ASP.NET Core
- **Carter** for minimal API endpoints
- **Entity Framework Core** with SQL Server
- **MediatR** for CQRS pattern
- **MassTransit** + RabbitMQ for messaging
- **Redis** for caching
- **OpenIddict** + Keycloak for authentication
- **Serilog** for structured logging

### Domain-Driven Design Patterns
- **Aggregates**: `Request` aggregate with encapsulated business logic
- **Value Objects**: `RequestDetail`, `Address`, `Contact`, `LoanDetail`, etc.
- **Domain Events**: `RequestCreatedEvent` with automatic dispatch
- **Repositories**: Interface-based with caching decorators
- **CQRS**: Commands for writes, queries for reads

### Key Architectural Patterns

#### Module Registration
Each module follows this pattern:
```csharp
services.AddRequestModule(configuration); // Register services
app.UseRequestModule(); // Configure middleware
```

#### Repository Pattern with Caching
```csharp
services.AddScoped<IRequestRepository, RequestRepository>();
services.Decorate<IRequestRepository, CachedRequestRepository>();
```

#### Carter Endpoints
API endpoints are defined using Carter modules:
```csharp
public class CreateRequestEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app) { /* ... */ }
}
```

#### DbContext per Module
- `RequestDbContext` for Request module
- `OpenIddictDbContext` for Auth module
- Each with custom interceptors for auditing and domain events

### Configuration
- **appsettings.json** contains:
  - SQL Server connection string (needs actual values)
  - Redis connection
  - RabbitMQ settings
  - Keycloak realm configuration
  - Serilog logging configuration

### Development Infrastructure
- **docker-compose.yml** provides all required services:
  - SQL Server (port 1433)
  - Redis (port 6379)  
  - RabbitMQ (port 5672, management UI 15672)
  - Keycloak (port 8080)
  - Seq logging (port 5341)

### Authentication Strategy
Dual authentication approach:
1. **OpenIddict**: Self-hosted OAuth2/OpenID Connect server
2. **Keycloak**: External identity provider integration

### Database Schema
- Each module uses its own schema namespace
- Automatic audit fields (`CreatedOn`, `CreatedBy`, `UpdatedOn`, `UpdatedBy`)
- Global conventions applied via `ModelBuilderExtension`

## Important Notes

- The main API project is in `Bootstrapper/Api`
- Each module is self-contained with its own DbContext and migrations
- Domain events are automatically dispatched during save operations
- All repositories use the decorator pattern for caching
- CQRS commands and queries are handled via MediatR
- Integration events flow through MassTransit/RabbitMQ
- Connection strings in appsettings.json need actual values for database access