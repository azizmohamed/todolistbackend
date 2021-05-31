# Todo List API
- This project is created for the purpose of Code testing
- API is hosting in Azure App Service https://todosgetc.azurewebsites.net
- API CI/CD is implemented using GitHub Actions

# Feature
- Development tools are ASP.Net Core and C#
- Data is hosted in SQL Server
- Swagger API documentation is implemented to help API consumers
- Custom Exception handler extensions are implemented to make errors user friendly in prod env
- Logging is implemented using Serilog
- Skeleton for Integration testing and Unit testing is added to the solution
- All controller methods are async based


# Todos and Enhancements
- Unit testing and integration testing logic need to be implemented. In memory integration could be used
- XML Comments don't appear on Swagger. More investigations needed for that issue.
- Custom business exception needs to be added to the logic for business errors
- Extra logging need to be added for some parts of the application.
- CI step for test needs to be added in Github Action workflow.
- Response types could be added to controllers for better usability and documentation.

