# OpenFaaS .NET templates

The repository contains templates for OpenFaaS and C#

Using the templates:

```sh
faas-cli template pull https://github.com/welteki/openfaas-csharp-templates
faas-cli new --list

Languages available as templates:
- csharp-minimal-api
```

## Minimal API template

OpenFaaS template based on the [ASP.NET Core Minimal API](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-8.0) 

```sh
faas-cli new --lang chsarp-minimal-api <fn-name>
```

### Example usage

Edit `Program.cs` and return a typed result:
```c#
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => TypedResults.Ok(new Message() { Text = "Hello World!!!" }));

app.Run();

public class Message
{
    public string? Text { get; set;}
}
```
