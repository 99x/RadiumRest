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


## Examples

#### Creating a REST web application

In order to create a REST web application or a microservice a developer should first specify the resource handler RadiumREST should use, create a server instance using a particular integration plugin (i.e. a plugin for .NET Core), and start the server. Optionally the developer could specify the port of the server through the configuration file of the web application.

```csharp
using RadiumRest;
using RadiumRest.Plugin.DotNetCore;

namespace RadiumRest.Sample.DotNetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Specify the REST resource handlers RadiumRest should use
            RadiumService.Use<CustomerService>(); 

            //Create the server with a particular integration plugin
            var server = RadiumService.Create<DotNetCoreRadiumPlugin>();

            //Start the server
            server.Start();
        }
    }
}
```


#### Creating a Resource

In order to create a REST resource the developer should create a class and inherit the base class RestResourceHandler. Then the developer could specify the REST resource which that handle should handle using the RestResource attribute. Next the related routes of the particular resource can be specified using the RestPath attribute. The RestPath attribute also enables the developer to map path parameters to the method parameters of the class.

```csharp
using RadiumRest;

namespace CustomerMicroservice
{

    [RestResource("customers")]
    public class CustomerService : RestResourceHandler
    {

        [RestPath("GET", "/@id")]
        public CustomerModel GetCustomer(int id)
        {           
            var customerRepository = new CustomerRepository();
            return customerRepository.GetCustomerById(id);
        }

        [RestPath("GET")]
        public List<CustomerModel> GetAllCustomers()
        {
            var customerRepository = new CustomerRepository();
            return customerRepository.GetAllCustomers();
        }

        [RestPath("POST")]
        public List<CustomerModel> CreateCustomer()
        {
            return customerRepository.CreateCustomer(this.Request.Body);
        }

    }
}

```


#### Creating a Filter

In order to create a filter the developer should inherit the base class AbstractFilter and overide the method Process and include the logic of the filter. To prevent the execution the FilterResponse.Success must be set to false. When that value is set to false the developer could specify the message and the HTTP status code the HTTP response should return. If the developer prefers to send data to the ResourceHandler he could include such data in the variable DataBag as a key value pair.

```csharp
    using RadiumRest;
    using RadiumRest.Core.Filters;

    public class AuthorizationFilter : AbstractFilter
    {
        public override void Process()
        {
            
            var authData = Authorizer.Authorize(Request.Body.userName, Request.Body.password);

            if (!authData.isSuccess){
                this.FilterResponse.StatusCode = 403;
                this.FilterResponse.Message = "Unauthorized";
                this.FilterResponse.Success = false;
            } else {
                DataBag.Add("authData", authData);
            }

        }
    }
```


#### Registering a Response Formatter

If the developer prefers to serialize a message for a particular content type, he could use a ResponseFormatter plugin. In the main application the developer could specify the formatter.

```csharp
    //Create the server using a particular plugin
    var server = RadiumService.Create<DotNetCoreRadiumPlugin>();
    
    //Integrate the JsonSchemaFormatter plugin
    server.Kernel.RegisterFormatter<JSONSchemaFormatter>();

    //Start the server
    server.Start();
```