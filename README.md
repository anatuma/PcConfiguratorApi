# PC Configurator API
This is a simple REST API designed to manage custom PC configurations and the hardware components inside them.
It uses **Entity Framework Core (EF Core)** with a **Code-First** approach to easily handle the database schema, relationships and migrations using C# models.

## What this API does
* **Full CRUD on PCs:** You can view all PCs, get details of a specific computer, build new configurations, update their specs or delete them.
* **Manage Components:** Get a full breakdown of what parts (and how many of each) are inside a specific PC build.
* **Relational Mapping Made Easy:** Uses EF Core's `Include` and `ThenInclude` to cleanly fetch a computer's parts, and maps the database entities directly into neat DTOs.
* **Database Models:** Features a proper Code-First relational schema containing tables like `PCs`, `Components`, `ComponentTypes` and `ComponentManufacturers`.

## Tech stack
* **Framework:** C# / ASP.NET Core Web API
* **ORM:** Entity Framework Core (Code-First)
* **Database:** SQL Server
* **API Testing:** Swagger UI / OpenAPI

## Getting started
1. **Set up the Database:**
   Open your terminal in the project directory and apply the EF Core migrations to generate your SQL Server database:
   ```bash
   dotnet ef database update