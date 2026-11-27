# Expense Tracker API

A REST API for tracking personal expenses and monthly budgets, built with **C# and ASP.NET Core** following **Clean Architecture** principles.

> **Status:** work in progress. See the [roadmap](#roadmap) for what is done and what is planned.

## Features

Planned:

- User registration and login with JWT authentication (access and refresh tokens)
- CRUD for categories and expenses, with strict per-user data ownership
- Filtering by date range and category, with pagination
- Monthly report with totals per category (aggregation done in SQL)
- Input validation and a consistent error format (RFC 7807 `ProblemDetails`)
- Monthly budget limits per category

## Tech Stack

| Area | Technology |
|---|---|
| Language / Framework | C#, ASP.NET Core Web API (.NET 10 LTS) |
| Data access | Entity Framework Core (code-first migrations) |
| Database | PostgreSQL |
| Authentication | JWT |
| Testing | xUnit, Testcontainers |
| API docs | Swagger / OpenAPI |
| DevOps | Docker, Docker Compose, GitHub Actions, Azure App Service |

## Architecture

The solution is split into four projects. Dependencies point **inwards only**:

```
Api ──────────────┐
                  ▼
Infrastructure ──► Application ──► Domain
```

| Project | Responsibility |
|---|---|
| `ExpenseTracker.Domain` | Entities and business rules. References no other project. |
| `ExpenseTracker.Application` | Use cases, services, DTOs and interfaces (e.g. repositories). |
| `ExpenseTracker.Infrastructure` | EF Core `DbContext`, migrations, repository implementations, external services. |
| `ExpenseTracker.Api` | Controllers, middleware, DI composition root, configuration. |

Keeping `Domain` free of framework dependencies makes business logic easy to unit test, and lets infrastructure details (such as the database) be swapped without touching it.

## Getting Started

### Prerequisites

- [.NET SDK 10](https://dotnet.microsoft.com/download)
- [Git](https://git-scm.com/)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (required from the database phase onwards)

### Run locally

```bash
git clone https://github.com/<your-username>/expense-tracker-api.git
cd expense-tracker-api
dotnet build
dotnet run --project src/ExpenseTracker.Api
```

The API listens on `http://localhost:5009` (see `launchSettings.json`).

### Verify it works

```bash
curl http://localhost:5009/api/health
```

Expected response:

```json
{ "status": "ok", "time": "2026-11-27T13:00:57.2196742Z" }
```

## Project Structure

```
ExpenseTracker/
├── src/
│   ├── ExpenseTracker.Domain/
│   ├── ExpenseTracker.Application/
│   ├── ExpenseTracker.Infrastructure/
│   └── ExpenseTracker.Api/
├── ExpenseTracker.sln
└── README.md
```

## Roadmap

- [x] **Phase 1:** solution structure with Clean Architecture layers, health endpoint
- [ ] **Phase 2:** PostgreSQL via Docker Compose, EF Core model and migrations
- [ ] **Phase 3:** CRUD for categories and expenses
- [ ] **Phase 4:** JWT authentication, refresh tokens and data ownership
- [ ] **Phase 5:** filtering, pagination and monthly report
- [ ] **Phase 6:** validation, global error handling, logging, Swagger
- [ ] **Phase 7:** unit and integration tests
- [ ] **Phase 8:** CI/CD with GitHub Actions and Docker image
- [ ] **Phase 9:** deployment to Azure

## Git Workflow

- `main` is always in a working state.
- Each phase is developed on a `feature/*` branch and merged through a Pull Request.
- Commits follow [Conventional Commits](https://www.conventionalcommits.org/) (`feat:`, `fix:`, `docs:`, `test:`, `refactor:`, `chore:`, `ci:`, `build:`).

## License

This project is for learning and portfolio purposes.