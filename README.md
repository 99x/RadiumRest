# RadiumREST - Microframework for .NET

RadiumREST is a Micoframework that enables you to easily write REST endpoints using .NET and host the application in any .NET compatible hosting environment such as .NET Core, OWIN, or IIS. Therefore the deployment decicision can be made even at a later stage of the project. This can also be used to develop microservices in .NET.

## Problems RadiumREST aims to solve

### Create REST Resources Using C# classes 
RadiumREST provides a productive programming paradigm that enables the developers to use C# classs to create REST resources and routes. This approach is similar to ASP.NET MVC but endpoints exposed using RadiumREST are compatible with any hosting environment

```csharp
    [RestResource("customers")]
    public class CustomerService : RestResourceHandler
    {

        [RestPath("GET", "/@id")]
        public CustomerModel GetCustomer(int id)
        {
            //Your business logic
        }
    }
```

### Write maintainable and portable microservices

### Losely couple business logic from ..hosting.. technology

### Extend the framework using plugins


## Features of RadiumREST

## Architecture of RadiumREST

## Hosting RadiumREST Microservices

## Examples

### Creating a Resource

### Creating a Filter

### Registering a Response Formatter