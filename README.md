# PC Configurator API

Build PCs in JSON. Swap parts. Delete the whole rig if you changed your mind about RGB.

This API manages custom computer configurations and the components inside them. **Entity Framework Core, Code-First** — migrations, relationships, `Include`/`ThenInclude`, the works. A nice contrast to my ADO.NET projects where I wrote SQL by hand.

## What it does

- **CRUD on PCs** — list, create, update, delete full configurations
- **Component breakdown** — see every part (and quantity) inside a specific build
- **Relational schema** — `PCs`, `Components`, `ComponentTypes`, `ComponentManufacturers`, join table `PCComponents`
- **DTO layer** — entities mapped to clean request/response objects

## Tech stack

- **C# / ASP.NET Core Web API**
- **EF Core** (Code-First + Migrations)
- **SQL Server**
- **Swagger** in Development

## API endpoints

| Method | Route | Notes |
|--------|-------|-------|
| `GET` | `/api/pcs` | All PC configurations |
| `GET` | `/api/pcs/{id}/components` | One PC with full parts list |
| `POST` | `/api/pcs` | Create a new build |
| `PUT` | `/api/pcs/{id}` | Update specs |
| `DELETE` | `/api/pcs/{id}` | Remove a build |

## Run it locally

1. **Set your connection string** in `appsettings.json` (default targets LocalDB):
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=PcManagementDB;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
   }
   ```
2. **Apply migrations:**
   ```bash
   dotnet ef database update
   ```
3. **Run the API:**
   ```bash
   dotnet run
   ```
4. Open Swagger at **http://localhost:5184/swagger**

Migrations live in `Migrations/` if you want to see how the schema evolved.
