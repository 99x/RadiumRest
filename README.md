# RadiumREST - Microframework for .NET

RadiumREST is a Micoframework that enables you to easily develop REST web applications, and microservices using C# and host the application in any .NET compatible hosting environment such as .NET Core, OWIN, or IIS. Therefore the deployment decicision can be made even at a later stage of the project.


## Features of RadiumREST

#### Create REST Resources Using C# classes 

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


#### Write maintainable and portable microservices

Rest resources created using RadiumREST can be hosted in any environment such as .NET core, IIS, or as a self hosted application. Plugins can be created for each hosting environment. currently plugins are available for .NET core, IIS, and OWIN self hosting.


#### Losely couple business logic from hosting technology

RadiumREST enables the developer to losely couple their business logic from technology which enables the developer to make hosting decisions even at a later stage of a project with less amount of coding changes. The developers can keep the REST resources, and business logic in a seperate class library and import that library to another project which also imports the relevent hosting plugin.


#### Extend the framework using plugins

RadiumREST enables the developers to extend the framework using plugins. Developers can use response formatter plugins to serialize any response of the service to a particular format based on the content type of the request. In addition to that plugins can be developped to support any hosting environment such as IIS, .NET Core, or self hosting using OWIN.

#### Use Filters to intercept HTTP requests before processing

Using filters developers could perform business specific functionality such as authorization and caching in their REST endpoints. Any auth provider or cache provider can be integrated using this mechanism.

## Architecture of RadiumREST

![alt text](https://github.com/99xt/RadiumRest/raw/master/doc/architecture.png)

Integration Plugins: Enables the developers to include plugins to support a particular hosting environment.

Filter Manager: Enables the developers to create filters to intercept HTTP requests and handle functionalities such as authorization or caching.

Resource Repository: Consists of information (i.e. routes and their respective classes and methods to handle the routes) about the REST resources created using the framework.

Service Invoker: When a REST request is being recieved, this component creates an instance of the relevent class and invokes the relavent method to handle the request. 
Response Formatter: Once the request is processed, this component serializes the response to a particular format according to the content type of the http request.

Rest Resource Handlers: Consists of the business logic to handle a particular REST request.

Microservice Specific Filters: Consists of the business specific filters.

## Hosting 


## Examples


### Creating a Resource


### Creating a Filter


### Registering a Response Formatter
