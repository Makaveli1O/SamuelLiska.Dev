## Architecture

WebApi
 └── BusinessLayer
      └── Infrastructure
           └── DataAccess
                └── Domain

| Layer            | Contains                                                     |
| ---------------- | ------------------------------------------------------------ |
| `Domain`         | Entities, no EF dependencies                                 |
| `DataAccess`     | EF `DbContext`, configurations, migrations                   |
| `Infrastructure` | `GameRepository`, `UnitOfWork`, `QueryHandlers` (CQRS)       |
| `BusinessLayer`  | `DTOs`, `IGameFacade`, `GameFacade`, Validation, Mappings    |
| `WebApi`         | Controllers, Swagger                                         |
