# ShareMyPaper

This project is a reference architecture for web application development.
It can be used as a bootstrap for ASP.NET Software Developemnt.

## Project features

- Unit and integration tests bootstrap (XUnit. Integration tests rely on inMemoryDb)
- Fullstack application (.NET C# Backend & Angular Frontend App)
- Authentication and Authorization (ASP .NET Identity)
- Property validation (Fluent Validation)
- Dto to Entity Mapping (AutoMapper)
- File Upload (Azure Blob Storage SDK)
- Continuous Integration and Continuous Deployment (Github action)
- Code first ORM approach (EF Core)
- Generic Repository
- Pagination for generic entities
- Docker container to build an deploy application

## Application Layers
   
   - **Domain:** contains application/DB Models/Entities
   - **Application:**
     - mapping of DTO's from/to entities
     - interfaces for repositories and services
   - **Web:** basically a Web API. supposed to be a thin layer that wire up all layers
     - Controllers
        - receive user input and delegate to other layers what to do
     - **Program:**
        - Application Config
        - Application Entrypoint
        - Dependency Injection
   - **Infraestructure:**
      - Actual implementation of services and repositories described by interfaces on Application layer
      - Responsible for interacting with external dependencies such as e-mail, storage and database
  

## Reference Architectural patterns

- Hexagonal Architecture (Ports and adapters)
  - https://alistair.cockburn.us/hexagonal-architecture/
- Clean Architecture
  - https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html
- Onion Architecture
  - https://jeffreypalermo.com/2013/08/onion-architecture-part-4-after-four-years
  
This patterns has as main principle the segregation of business rules and functional specification from implementation details, such as Database, UI and Web Framework. 
The idea is that the system core value should be independent from runtime such as web or CLI.
  
 It is heavily inspired by the following projects: 
  - https://github.com/dotnet-architecture/eShopOnWeb
  - https://github.com/jasontaylordev/CleanArchitecture
  - https://github.com/ardalis/CleanArchitecture
  - https://github.com/rafaelfgx/Architecture
  
  
 
