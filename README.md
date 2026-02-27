# FirstERP (Clean Architecture)

Simple ERP starter built with:
- ASP.NET Core MVC (`cshtml` + C#)
- ADO.NET (`Microsoft.Data.SqlClient`)
- SQL Server
- CSS + JavaScript
- Clean Architecture layering (Domain, Application, Infrastructure, Web)

## Structure

- `src/FirstERP.Domain`: Entities and repository contracts
- `src/FirstERP.Application`: Use-case services and DTOs
- `src/FirstERP.Infrastructure`: SQL Server data access (ADO.NET)
- `src/FirstERP.Web`: MVC UI (Controllers, Views, static assets)
- `database`: SQL scripts for schema

## Run in Visual Studio

1. Open `FirstERP.sln` in Visual Studio 2022.
2. Run `database/01_create_products_table.sql` against SQL Server.
3. Update connection string in `src/FirstERP.Web/appsettings.json` if needed.
4. Set `FirstERP.Web` as startup project and run.

## Key flow

`ProductController -> IProductService -> IProductRepository -> SQL Server`
