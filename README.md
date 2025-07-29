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
| `Infrastructure` | `GameRepository`, `UnitOfWork`, `GenericRepositories`        |
| `BusinessLayer`  | `DTOs`, `Mappings`, `Facades`, Validation, App services      |
| `WebApi`         | Controllers, Swagger, Presentation                           |
